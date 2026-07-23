using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanuden.Rudolf;
using Tanuden.Rudolf.Enums;
using Tanuden.Rudolf.Json;

namespace TrainDataRecorder
{
    public partial class Form1 : Form
    {
        IRudolfAdapter Adapter;
        OutputDataFrame Frame;
        List<DataField> SelectedDataFields;

        RecorderModes RecorderMode = RecorderModes.Disabled;
        float Frequency = 10;
        int NumCars = 6;
        string OutputPath = "output.csv";

        bool EuropeMode = false;
        string ItemDelimiter = "";
        NumberFormatInfo NumberFormat = CultureInfo.InvariantCulture.NumberFormat;

        bool WriteSimProfiles = false;
        string PrevScenarioId = "";
        string ProfilePath = "";
        string ProfileSuffix = ".sp.json";
        JsonSerializerOptions ProfileJsonSerializerOptions = new(RudolfJson.Options) { WriteIndented = true };

        FileStream fs;
        System.Timers.Timer timer;

        // Need to keep track of this value as SelectedItems.Count does not update immediately
        int NumDataSelected = 0;

        const string OutputFileHeader = "TrainDataRecorder Output V1";
        const string NumDataSelectedText = "x 有効";

        public Form1()
        {
            InitializeComponent();

            // Load names of data fields into the list box system
            listBoxDataAvailable.BeginUpdate();
            listBoxDataAvailable.Items.AddRange(Enum.GetNames(typeof(DataField)));
            listBoxDataAvailable.EndUpdate();

            textBoxFilePath.Text = OutputPath;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (listBoxDataAvailable.SelectedItems.Count > 0)
            {
                listBoxDataSelected.BeginUpdate();
                foreach (object item in listBoxDataAvailable.SelectedItems)
                {
                    listBoxDataSelected.Items.Add(item);
                    NumDataSelected++;
                }
                listBoxDataSelected.EndUpdate();
            }

            labelNumDataSelected.Text = NumDataSelected.ToString() + NumDataSelectedText;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxDataSelected.SelectedIndex;
            int itemCount = listBoxDataSelected.Items.Count;

            if (selectedIndex >= 0 && selectedIndex < itemCount)
            {
                listBoxDataSelected.BeginUpdate();
                listBoxDataSelected.Items.RemoveAt(listBoxDataSelected.SelectedIndex);
                listBoxDataSelected.SelectedIndex = Math.Min(selectedIndex, itemCount - 2);
                listBoxDataSelected.EndUpdate();

                NumDataSelected--;
            }

            labelNumDataSelected.Text = NumDataSelected.ToString() + NumDataSelectedText;
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (listBoxDataSelected.SelectedIndex >= 1 && listBoxDataSelected.SelectedIndex < listBoxDataSelected.Items.Count)
            {
                listBoxDataSelected.BeginUpdate();

                object temp = listBoxDataSelected.Items[listBoxDataSelected.SelectedIndex];
                listBoxDataSelected.Items[listBoxDataSelected.SelectedIndex] = listBoxDataSelected.Items[listBoxDataSelected.SelectedIndex - 1];
                listBoxDataSelected.Items[listBoxDataSelected.SelectedIndex - 1] = temp;

                listBoxDataSelected.SelectedIndex--;
                listBoxDataSelected.EndUpdate();
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (listBoxDataSelected.SelectedIndex >= 0 && listBoxDataSelected.SelectedIndex < listBoxDataSelected.Items.Count - 1)
            {
                listBoxDataSelected.BeginUpdate();

                object temp = listBoxDataSelected.Items[listBoxDataSelected.SelectedIndex];
                listBoxDataSelected.Items[listBoxDataSelected.SelectedIndex] = listBoxDataSelected.Items[listBoxDataSelected.SelectedIndex + 1];
                listBoxDataSelected.Items[listBoxDataSelected.SelectedIndex + 1] = temp;

                listBoxDataSelected.SelectedIndex++;
                listBoxDataSelected.EndUpdate();
            }
        }

        private void buttonFilePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = dialog.FileName;
            }
        }

        private void ValidateFrequencyValue()
        {
            float result;
            bool success = float.TryParse(textBoxFrequency.Text, CultureInfo.InvariantCulture, out result);

            if (!success || result <= 0)
            {
                // Discard result value, do not update setting
            }
            else
            {
                Frequency = result;
            }

            textBoxFrequency.Text = Frequency.ToString(CultureInfo.InvariantCulture);
        }

        private void textBoxFrequency_Leave(object sender, EventArgs e)
        {
            ValidateFrequencyValue();
        }

        private void textBoxFrequency_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidateFrequencyValue();
            }
        }

        private void ValidateNumCarsValue()
        {
            int result;
            bool success = int.TryParse(textBoxNumCars.Text, CultureInfo.InvariantCulture, out result);

            if (!success || result <= 0)
            {
                // Discard result value, do not update setting
            }
            else
            {
                NumCars = result;
            }

            textBoxNumCars.Text = NumCars.ToString(CultureInfo.InvariantCulture);
        }

        private void textBoxNumCars_Leave(object sender, EventArgs e)
        {
            ValidateNumCarsValue();
        }

        private void textBoxNumCars_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidateNumCarsValue();
            }
        }

        private void PrepareStartRecording()
        {
            // Change the interactivity of elements
            groupBoxData.Enabled = false;
            panelDataSelect.Enabled = false;
            buttonStartTrainCrew.Enabled = false;
            buttonStartBVE.Enabled = false;
            buttonStop.Enabled = true;

            timer = new System.Timers.Timer((double)(1000f / Frequency));
            timer.Elapsed += OnTimerTick;
            timer.Start();

            EuropeMode = checkBoxEuroMode.Checked;
            if (EuropeMode)
            {
                ItemDelimiter = ";";
                NumberFormat = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = ",",
                    PercentDecimalSeparator = ","
                };
            }
            else
            {
                ItemDelimiter = ",";
                NumberFormat = CultureInfo.InvariantCulture.NumberFormat;
            }

            WriteSimProfiles = checkBoxSimProfile.Checked;

            OutputPath = textBoxFilePath.Text;
            try
            {
                fs = new FileStream(OutputPath, FileMode.Create);
            }
            catch (Exception ex)
            {
                PrepareStopRecording();
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            ProfilePath = OutputPath + ProfileSuffix;

            SelectedDataFields = new List<DataField>();
            foreach (string s in listBoxDataSelected.Items)
            {
                SelectedDataFields.Add(Enum.Parse<DataField>(s));
            }
            if (SelectedDataFields.Count == 0)
            {
                PrepareStopRecording();
                MessageBox.Show("No data channels selected.", "Error");
                return;
            }

            // File header
            fs.Write(Encoding.UTF8.GetBytes(OutputFileHeader + "\n"));

            // Column titles
            foreach (DataField df in SelectedDataFields)
            {
                // First write the channel name
                fs.Write(Encoding.UTF8.GetBytes(df.ToString()));

                int numCommas;
                if (df == DataField.doors_perCar_carNo || df == DataField.doors_perCar_sideOpened ||
                    df == DataField.cars_amperage || df == DataField.cars_bcPressure ||
                    df == DataField.cars_carNo || df == DataField.cars_occupancyRate)
                {
                    // Per-car channels occupy NumCars columns, write NumCars commas
                    numCommas = NumCars;
                }
                else
                {
                    // Normal channels occupy one column each, so only one comma
                    numCommas = 1;
                }

                for (int i = 0; i < numCommas; i++)
                {
                    fs.Write(Encoding.UTF8.GetBytes(ItemDelimiter));
                }
            }
            fs.Write(Encoding.UTF8.GetBytes("\n"));
        }

        private void buttonStartTrainCrew_Click(object sender, EventArgs e)
        {
            RecorderMode = RecorderModes.TrainCrew;
            PrepareStartRecording();

            TrainCrew.TrainCrewInput.Init();
            Adapter = new Tanuden.Rudolf.Adapters.TrainCrew.TrainCrewRudolfAdapter();
            Adapter.Start();
        }

        private void buttonStartBVE_Click(object sender, EventArgs e)
        {
            RecorderMode = RecorderModes.BVE;
            PrepareStartRecording();

            Adapter = new Tanuden.Rudolf.Adapters.Bve.BveRudolfAdapter();
            Adapter.Start();
        }

        private void PrepareStopRecording()
        {
            // Change the interactivity of elements
            groupBoxData.Enabled = true;
            panelDataSelect.Enabled = true;
            buttonStartTrainCrew.Enabled = true;
            buttonStartBVE.Enabled = true;
            buttonStop.Enabled = false;

            // Signal to stop the adapter
            // Cannot close adapter directly here as it may be processing a frame ==> close at end of tick
            RecorderMode = RecorderModes.Disabled;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            PrepareStopRecording();
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (RecorderMode != RecorderModes.Disabled)
            {
                if (Adapter is null)
                {

                    PrepareStopRecording();
                    MessageBox.Show("Data access adapter unavailable.", "Error");
                    return;
                }

                Frame = Adapter.GetCurrentFrame();
                if (Frame is null)
                {
                    return;
                }

                bool inGame = Frame.GameState.Screen == GameScreen.MainGame || Frame.GameState.Screen == GameScreen.Other;
                if (!inGame)
                {
                    return;
                }

                // Generate the line for this frame
                // Go through all selected datasets
                foreach (DataField dataField in SelectedDataFields)
                {
                    fs.Write(Encoding.UTF8.GetBytes(GetDataString(Frame, dataField, NumCars, EuropeMode, NumberFormat) + ItemDelimiter));
                }
                fs.Write(Encoding.UTF8.GetBytes("\n"));

                // Simulator Profile JSON file
                if (WriteSimProfiles && Frame.ScenarioId != PrevScenarioId)
                {
                    PrevScenarioId = Frame.ScenarioId;
                    SimulatorProfile? profile = Adapter.GetProfile();
                    if (profile != null)
                    {
                        File.WriteAllText(ProfilePath, JsonSerializer.Serialize(profile, ProfileJsonSerializerOptions));
                    }
                }
            }
            else
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }

                if (timer != null)
                {
                    timer.Dispose();
                }

                if (Adapter != null)
                {
                    Adapter.Dispose();
                }
            }
        }
    }
}
