
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
            listBoxDataAvailable = new ListBox();
            listBoxDataSelected = new ListBox();
            buttonAdd = new Button();
            buttonRemove = new Button();
            panelDataSelect = new Panel();
            labelNumDataSelected = new Label();
            label6 = new Label();
            buttonMoveDown = new Button();
            buttonMoveUp = new Button();
            groupBoxInit = new GroupBox();
            buttonStop = new Button();
            buttonStartTrainCrew = new Button();
            groupBoxData = new GroupBox();
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
            panelDataSelect.SuspendLayout();
            groupBoxInit.SuspendLayout();
            groupBoxData.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxDataAvailable
            // 
            listBoxDataAvailable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxDataAvailable.FormattingEnabled = true;
            listBoxDataAvailable.Location = new Point(0, 0);
            listBoxDataAvailable.Margin = new Padding(4, 3, 4, 3);
            listBoxDataAvailable.Name = "listBoxDataAvailable";
            listBoxDataAvailable.SelectionMode = SelectionMode.MultiExtended;
            listBoxDataAvailable.Size = new Size(291, 214);
            listBoxDataAvailable.TabIndex = 20;
            // 
            // listBoxDataSelected
            // 
            listBoxDataSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            listBoxDataSelected.FormattingEnabled = true;
            listBoxDataSelected.Location = new Point(362, 0);
            listBoxDataSelected.Margin = new Padding(4, 3, 4, 3);
            listBoxDataSelected.Name = "listBoxDataSelected";
            listBoxDataSelected.Size = new Size(291, 214);
            listBoxDataSelected.TabIndex = 25;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonAdd.Location = new Point(297, 74);
            buttonAdd.Margin = new Padding(4, 3, 4, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(61, 27);
            buttonAdd.TabIndex = 22;
            buttonAdd.Text = "→";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonRemove.Location = new Point(297, 113);
            buttonRemove.Margin = new Padding(4, 3, 4, 3);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(61, 27);
            buttonRemove.TabIndex = 23;
            buttonRemove.Text = "←";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
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
            panelDataSelect.Location = new Point(14, 173);
            panelDataSelect.Margin = new Padding(4, 3, 4, 3);
            panelDataSelect.Name = "panelDataSelect";
            panelDataSelect.Size = new Size(662, 235);
            panelDataSelect.TabIndex = 4;
            // 
            // labelNumDataSelected
            // 
            labelNumDataSelected.Location = new Point(552, 217);
            labelNumDataSelected.Name = "labelNumDataSelected";
            labelNumDataSelected.Size = new Size(99, 15);
            labelNumDataSelected.TabIndex = 8;
            labelNumDataSelected.Text = "0つ有効";
            labelNumDataSelected.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 217);
            label6.Name = "label6";
            label6.Size = new Size(163, 15);
            label6.TabIndex = 6;
            label6.Text = "使用可能なデーターチャンネル";
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonMoveDown.Location = new Point(329, 187);
            buttonMoveDown.Margin = new Padding(4, 3, 4, 3);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(29, 27);
            buttonMoveDown.TabIndex = 24;
            buttonMoveDown.Text = "↓";
            buttonMoveDown.UseVisualStyleBackColor = true;
            buttonMoveDown.Click += buttonMoveDown_Click;
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
            // groupBoxInit
            // 
            groupBoxInit.Controls.Add(buttonStop);
            groupBoxInit.Controls.Add(buttonStartTrainCrew);
            groupBoxInit.Location = new Point(456, 14);
            groupBoxInit.Margin = new Padding(4, 3, 4, 3);
            groupBoxInit.Name = "groupBoxInit";
            groupBoxInit.Padding = new Padding(4, 3, 4, 3);
            groupBoxInit.Size = new Size(211, 141);
            groupBoxInit.TabIndex = 1;
            groupBoxInit.TabStop = false;
            groupBoxInit.Text = "レコーダー　モード・切";
            // 
            // buttonStop
            // 
            buttonStop.Enabled = false;
            buttonStop.Location = new Point(7, 107);
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
            groupBoxData.Size = new Size(414, 141);
            groupBoxData.TabIndex = 0;
            groupBoxData.TabStop = false;
            groupBoxData.Text = "設定";
            // 
            // checkBoxEuroMode
            // 
            checkBoxEuroMode.AutoSize = true;
            checkBoxEuroMode.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxEuroMode.Location = new Point(305, 79);
            checkBoxEuroMode.Name = "checkBoxEuroMode";
            checkBoxEuroMode.Size = new Size(97, 19);
            checkBoxEuroMode.TabIndex = 4;
            checkBoxEuroMode.Text = "Europe Mode";
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
            buttonFilePath.Size = new Size(36, 27);
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
            panelDataSelect.ResumeLayout(false);
            panelDataSelect.PerformLayout();
            groupBoxInit.ResumeLayout(false);
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDataAvailable;
        private System.Windows.Forms.ListBox listBoxDataSelected;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Panel panelDataSelect;
        private System.Windows.Forms.GroupBox groupBoxInit;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStartTrainCrew;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonMoveUp;
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
        private Label label6;
        private Label labelNumDataSelected;
        private CheckBox checkBoxEuroMode;
    }
}

