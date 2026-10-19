
namespace TrainDataRecorder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxInit = new GroupBox();
            buttonStartDerailValley = new Button();
            buttonStartBVE = new Button();
            buttonStop = new Button();
            buttonStartTrainCrew = new Button();
            groupBoxData = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            textBoxNumBogies = new TextBox();
            checkBoxDataFrame = new CheckBox();
            checkBoxSimProfile = new CheckBox();
            checkBoxEuroMode = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBoxFrequency = new TextBox();
            textBoxNumCars = new TextBox();
            buttonFilePath = new Button();
            label1 = new Label();
            textBoxFilePath = new TextBox();
            buttonAdd = new Button();
            listBoxDataSelected = new ListBox();
            buttonRemove = new Button();
            listBoxDataAvailable = new ListBox();
            buttonMoveUp = new Button();
            buttonMoveDown = new Button();
            label6 = new Label();
            labelNumDataSelected = new Label();
            panelDataSelect = new Panel();
            groupBoxInit.SuspendLayout();
            groupBoxData.SuspendLayout();
            panelDataSelect.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxInit
            // 
            groupBoxInit.Controls.Add(buttonStartDerailValley);
            groupBoxInit.Controls.Add(buttonStartBVE);
            groupBoxInit.Controls.Add(buttonStop);
            groupBoxInit.Controls.Add(buttonStartTrainCrew);
            groupBoxInit.Location = new Point(456, 14);
            groupBoxInit.Margin = new Padding(4, 3, 4, 3);
            groupBoxInit.Name = "groupBoxInit";
            groupBoxInit.Padding = new Padding(4, 3, 4, 3);
            groupBoxInit.Size = new Size(211, 175);
            groupBoxInit.TabIndex = 1;
            groupBoxInit.TabStop = false;
            groupBoxInit.Text = "レコーダー　開始・切";
            // 
            // buttonStartDerailValley
            // 
            buttonStartDerailValley.Location = new Point(7, 90);
            buttonStartDerailValley.Margin = new Padding(4, 3, 4, 3);
            buttonStartDerailValley.Name = "buttonStartDerailValley";
            buttonStartDerailValley.Size = new Size(197, 27);
            buttonStartDerailValley.TabIndex = 13;
            buttonStartDerailValley.Text = "DERAIL VALLEY";
            buttonStartDerailValley.UseVisualStyleBackColor = true;
            buttonStartDerailValley.Click += buttonStartDerailValley_Click;
            // 
            // buttonStartBVE
            // 
            buttonStartBVE.Location = new Point(7, 56);
            buttonStartBVE.Margin = new Padding(4, 3, 4, 3);
            buttonStartBVE.Name = "buttonStartBVE";
            buttonStartBVE.Size = new Size(197, 27);
            buttonStartBVE.TabIndex = 12;
            buttonStartBVE.Text = "BVE";
            buttonStartBVE.UseVisualStyleBackColor = true;
            buttonStartBVE.Click += buttonStartBVE_Click;
            // 
            // buttonStop
            // 
            buttonStop.Enabled = false;
            buttonStop.Location = new Point(7, 136);
            buttonStop.Margin = new Padding(4, 3, 4, 3);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(197, 27);
            buttonStop.TabIndex = 11;
            buttonStop.Text = "STOP";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonStartTrainCrew
            // 
            buttonStartTrainCrew.Location = new Point(7, 23);
            buttonStartTrainCrew.Margin = new Padding(4, 3, 4, 3);
            buttonStartTrainCrew.Name = "buttonStartTrainCrew";
            buttonStartTrainCrew.Size = new Size(197, 27);
            buttonStartTrainCrew.TabIndex = 10;
            buttonStartTrainCrew.Text = "TRAIN CREW";
            buttonStartTrainCrew.UseVisualStyleBackColor = true;
            buttonStartTrainCrew.Click += buttonStartTrainCrew_Click;
            // 
            // groupBoxData
            // 
            groupBoxData.Controls.Add(label8);
            groupBoxData.Controls.Add(label7);
            groupBoxData.Controls.Add(textBoxNumBogies);
            groupBoxData.Controls.Add(checkBoxDataFrame);
            groupBoxData.Controls.Add(checkBoxSimProfile);
            groupBoxData.Controls.Add(checkBoxEuroMode);
            groupBoxData.Controls.Add(label5);
            groupBoxData.Controls.Add(label4);
            groupBoxData.Controls.Add(label3);
            groupBoxData.Controls.Add(label2);
            groupBoxData.Controls.Add(textBoxFrequency);
            groupBoxData.Controls.Add(textBoxNumCars);
            groupBoxData.Controls.Add(buttonFilePath);
            groupBoxData.Controls.Add(label1);
            groupBoxData.Controls.Add(textBoxFilePath);
            groupBoxData.Location = new Point(14, 14);
            groupBoxData.Margin = new Padding(4, 3, 4, 3);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Padding = new Padding(4, 3, 4, 3);
            groupBoxData.Size = new Size(414, 175);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "設定";
            // 
            // label8
            // 
            label8.Location = new Point(188, 136);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(124, 24);
            label8.TabIndex = 17;
            label8.Text = "No. of bogies";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Location = new Point(7, 136);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(76, 24);
            label7.TabIndex = 16;
            label7.Text = "台車数";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxNumBogies
            // 
            textBoxNumBogies.Location = new Point(90, 136);
            textBoxNumBogies.Margin = new Padding(4, 3, 4, 3);
            textBoxNumBogies.Name = "textBoxNumBogies";
            textBoxNumBogies.Size = new Size(90, 23);
            textBoxNumBogies.TabIndex = 15;
            textBoxNumBogies.Text = "2";
            textBoxNumBogies.KeyUp += textBoxNumBogies_KeyUp;
            textBoxNumBogies.Leave += textBoxNumBogies_Leave;
            // 
            // checkBoxDataFrame
            // 
            checkBoxDataFrame.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxDataFrame.Location = new Point(264, 99);
            checkBoxDataFrame.Name = "checkBoxDataFrame";
            checkBoxDataFrame.Size = new Size(138, 19);
            checkBoxDataFrame.TabIndex = 14;
            checkBoxDataFrame.Text = "Data Frame JSON";
            checkBoxDataFrame.TextAlign = ContentAlignment.MiddleRight;
            checkBoxDataFrame.UseVisualStyleBackColor = true;
            // 
            // checkBoxSimProfile
            // 
            checkBoxSimProfile.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxSimProfile.Location = new Point(264, 119);
            checkBoxSimProfile.Name = "checkBoxSimProfile";
            checkBoxSimProfile.Size = new Size(138, 19);
            checkBoxSimProfile.TabIndex = 13;
            checkBoxSimProfile.Text = "Sim Profile JSON";
            checkBoxSimProfile.TextAlign = ContentAlignment.MiddleRight;
            checkBoxSimProfile.UseVisualStyleBackColor = true;
            // 
            // checkBoxEuroMode
            // 
            checkBoxEuroMode.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxEuroMode.Location = new Point(264, 79);
            checkBoxEuroMode.Name = "checkBoxEuroMode";
            checkBoxEuroMode.Size = new Size(138, 19);
            checkBoxEuroMode.TabIndex = 4;
            checkBoxEuroMode.Text = "European Mode";
            checkBoxEuroMode.TextAlign = ContentAlignment.MiddleRight;
            checkBoxEuroMode.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Location = new Point(188, 106);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(124, 24);
            label5.TabIndex = 12;
            label5.Text = "No. of cars";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(188, 76);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(76, 24);
            label4.TabIndex = 11;
            label4.Text = "Frequency";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(7, 107);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(76, 24);
            label3.TabIndex = 10;
            label3.Text = "両数";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(7, 77);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 24);
            label2.TabIndex = 9;
            label2.Text = "頻度 (Hz)";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxFrequency
            // 
            textBoxFrequency.Location = new Point(90, 77);
            textBoxFrequency.Margin = new Padding(4, 3, 4, 3);
            textBoxFrequency.Name = "textBoxFrequency";
            textBoxFrequency.Size = new Size(90, 23);
            textBoxFrequency.TabIndex = 2;
            textBoxFrequency.Text = "10";
            textBoxFrequency.KeyUp += textBoxFrequency_KeyUp;
            textBoxFrequency.Leave += textBoxFrequency_Leave;
            // 
            // textBoxNumCars
            // 
            textBoxNumCars.Location = new Point(90, 107);
            textBoxNumCars.Margin = new Padding(4, 3, 4, 3);
            textBoxNumCars.Name = "textBoxNumCars";
            textBoxNumCars.Size = new Size(90, 23);
            textBoxNumCars.TabIndex = 3;
            textBoxNumCars.Text = "6";
            textBoxNumCars.KeyUp += textBoxNumCars_KeyUp;
            textBoxNumCars.Leave += textBoxNumCars_Leave;
            // 
            // buttonFilePath
            // 
            buttonFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonFilePath.Location = new Point(366, 22);
            buttonFilePath.Margin = new Padding(4, 3, 4, 3);
            buttonFilePath.Name = "buttonFilePath";
            buttonFilePath.Size = new Size(36, 28);
            buttonFilePath.TabIndex = 1;
            buttonFilePath.Text = "...";
            buttonFilePath.UseVisualStyleBackColor = true;
            buttonFilePath.Click += buttonFilePath_Click;
            // 
            // label1
            // 
            label1.Location = new Point(7, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 24);
            label1.TabIndex = 1;
            label1.Text = "ファイルパス";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(90, 24);
            textBoxFilePath.Margin = new Padding(4, 3, 4, 3);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(268, 23);
            textBoxFilePath.TabIndex = 0;
            textBoxFilePath.Text = "output.csv";
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonAdd.Location = new Point(297, 62);
            buttonAdd.Margin = new Padding(4, 3, 4, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(61, 27);
            buttonAdd.TabIndex = 22;
            buttonAdd.Text = "→";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // listBoxDataSelected
            // 
            listBoxDataSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            listBoxDataSelected.FormattingEnabled = true;
            listBoxDataSelected.Location = new Point(362, 0);
            listBoxDataSelected.Margin = new Padding(4, 3, 4, 3);
            listBoxDataSelected.Name = "listBoxDataSelected";
            listBoxDataSelected.Size = new Size(291, 184);
            listBoxDataSelected.TabIndex = 25;
            // 
            // buttonRemove
            // 
            buttonRemove.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonRemove.Location = new Point(297, 95);
            buttonRemove.Margin = new Padding(4, 3, 4, 3);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(61, 27);
            buttonRemove.TabIndex = 23;
            buttonRemove.Text = "←";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // listBoxDataAvailable
            // 
            listBoxDataAvailable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxDataAvailable.FormattingEnabled = true;
            listBoxDataAvailable.Location = new Point(0, 0);
            listBoxDataAvailable.Margin = new Padding(4, 3, 4, 3);
            listBoxDataAvailable.Name = "listBoxDataAvailable";
            listBoxDataAvailable.SelectionMode = SelectionMode.MultiExtended;
            listBoxDataAvailable.Size = new Size(291, 184);
            listBoxDataAvailable.TabIndex = 20;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonMoveUp.Location = new Point(329, 0);
            buttonMoveUp.Margin = new Padding(4, 3, 4, 3);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(29, 27);
            buttonMoveUp.TabIndex = 21;
            buttonMoveUp.Text = "↑";
            buttonMoveUp.UseVisualStyleBackColor = true;
            buttonMoveUp.Click += buttonMoveUp_Click;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonMoveDown.Location = new Point(329, 157);
            buttonMoveDown.Margin = new Padding(4, 3, 4, 3);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(29, 27);
            buttonMoveDown.TabIndex = 24;
            buttonMoveDown.Text = "↓";
            buttonMoveDown.UseVisualStyleBackColor = true;
            buttonMoveDown.Click += buttonMoveDown_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 187);
            label6.Name = "label6";
            label6.Size = new Size(163, 15);
            label6.TabIndex = 6;
            label6.Text = "使用可能なデーターチャンネル";
            // 
            // labelNumDataSelected
            // 
            labelNumDataSelected.Location = new Point(554, 187);
            labelNumDataSelected.Name = "labelNumDataSelected";
            labelNumDataSelected.Size = new Size(99, 15);
            labelNumDataSelected.TabIndex = 8;
            labelNumDataSelected.Text = "0x 有効";
            labelNumDataSelected.TextAlign = ContentAlignment.TopRight;
            // 
            // panelDataSelect
            // 
            panelDataSelect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelDataSelect.AutoSize = true;
            panelDataSelect.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelDataSelect.Controls.Add(labelNumDataSelected);
            panelDataSelect.Controls.Add(label6);
            panelDataSelect.Controls.Add(buttonMoveDown);
            panelDataSelect.Controls.Add(buttonMoveUp);
            panelDataSelect.Controls.Add(listBoxDataAvailable);
            panelDataSelect.Controls.Add(buttonRemove);
            panelDataSelect.Controls.Add(listBoxDataSelected);
            panelDataSelect.Controls.Add(buttonAdd);
            panelDataSelect.Location = new Point(13, 195);
            panelDataSelect.Margin = new Padding(4, 3, 4, 3);
            panelDataSelect.Name = "panelDataSelect";
            panelDataSelect.Size = new Size(662, 210);
            panelDataSelect.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 417);
            Controls.Add(groupBoxData);
            Controls.Add(groupBoxInit);
            Controls.Add(panelDataSelect);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "TrainDataRecorder";
            groupBoxInit.ResumeLayout(false);
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            panelDataSelect.ResumeLayout(false);
            panelDataSelect.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxInit;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStartTrainCrew;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Button buttonFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.TextBox textBoxFrequency;
        private System.Windows.Forms.TextBox textBoxNumCars;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private CheckBox checkBoxEuroMode;
        private Button buttonStartBVE;
        private CheckBox checkBoxSimProfile;
        private CheckBox checkBoxDataFrame;
        private Button buttonAdd;
        private ListBox listBoxDataSelected;
        private Button buttonRemove;
        private ListBox listBoxDataAvailable;
        private Button buttonMoveUp;
        private Button buttonMoveDown;
        private Label label6;
        private Label labelNumDataSelected;
        private Panel panelDataSelect;
        private Label label8;
        private Label label7;
        private TextBox textBoxNumBogies;
        private Button buttonStartDerailValley;
    }
}

