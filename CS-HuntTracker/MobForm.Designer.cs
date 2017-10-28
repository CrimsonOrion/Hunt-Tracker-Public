namespace CS_HuntTracker
{
    partial class MobForm
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
            this.JustDiedRadio = new System.Windows.Forms.RadioButton();
            this.DiedAtRadio = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.DeathDate = new System.Windows.Forms.DateTimePicker();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DeathTimeMinute = new System.Windows.Forms.ComboBox();
            this.DeathTimeHour = new System.Windows.Forms.ComboBox();
            this.MobPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MobPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // JustDiedRadio
            // 
            this.JustDiedRadio.AutoSize = true;
            this.JustDiedRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JustDiedRadio.Location = new System.Drawing.Point(12, 238);
            this.JustDiedRadio.Name = "JustDiedRadio";
            this.JustDiedRadio.Size = new System.Drawing.Size(76, 19);
            this.JustDiedRadio.TabIndex = 0;
            this.JustDiedRadio.Text = "Just Died";
            this.JustDiedRadio.UseVisualStyleBackColor = true;
            this.JustDiedRadio.CheckedChanged += new System.EventHandler(this.JustDiedRadio_CheckedChanged);
            // 
            // DiedAtRadio
            // 
            this.DiedAtRadio.AutoSize = true;
            this.DiedAtRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiedAtRadio.Location = new System.Drawing.Point(12, 261);
            this.DiedAtRadio.Name = "DiedAtRadio";
            this.DiedAtRadio.Size = new System.Drawing.Size(64, 19);
            this.DiedAtRadio.TabIndex = 1;
            this.DiedAtRadio.TabStop = true;
            this.DiedAtRadio.Text = "Died at";
            this.DiedAtRadio.UseVisualStyleBackColor = true;
            this.DiedAtRadio.CheckedChanged += new System.EventHandler(this.DiedAtRadio_CheckedChanged);
            // 
            // OKButton
            // 
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(352, 260);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(50, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "Ok";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DeathDate
            // 
            this.DeathDate.Enabled = false;
            this.DeathDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeathDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DeathDate.Location = new System.Drawing.Point(82, 260);
            this.DeathDate.Name = "DeathDate";
            this.DeathDate.ShowUpDown = true;
            this.DeathDate.Size = new System.Drawing.Size(88, 21);
            this.DeathDate.TabIndex = 2;
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(352, 231);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(50, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = ":";
            // 
            // DeathTimeMinute
            // 
            this.DeathTimeMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeathTimeMinute.DropDownWidth = 42;
            this.DeathTimeMinute.Enabled = false;
            this.DeathTimeMinute.FormattingEnabled = true;
            this.DeathTimeMinute.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.DeathTimeMinute.Location = new System.Drawing.Point(285, 260);
            this.DeathTimeMinute.Name = "DeathTimeMinute";
            this.DeathTimeMinute.Size = new System.Drawing.Size(48, 21);
            this.DeathTimeMinute.TabIndex = 4;
            // 
            // DeathTimeHour
            // 
            this.DeathTimeHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeathTimeHour.DropDownWidth = 70;
            this.DeathTimeHour.Enabled = false;
            this.DeathTimeHour.FormattingEnabled = true;
            this.DeathTimeHour.Items.AddRange(new object[] {
            "00 / Midnight",
            "01 / 1 AM",
            "02 / 2 AM",
            "03 / 3 AM",
            "04 / 4 AM",
            "05 / 5 AM",
            "06 / 6 AM",
            "07 / 7 AM",
            "08 / 8 AM",
            "09 / 9 AM",
            "10 / 10 AM",
            "11 / 11 AM",
            "12 / Noon",
            "13 / 1 PM",
            "14 / 2 PM",
            "15 / 3 PM",
            "16 / 4 PM",
            "17 / 5 PM",
            "18 / 6 PM",
            "19 / 7 PM",
            "20 / 8 PM",
            "21 / 9 PM",
            "22 / 10 PM",
            "23 / 11 PM"});
            this.DeathTimeHour.Location = new System.Drawing.Point(176, 260);
            this.DeathTimeHour.Name = "DeathTimeHour";
            this.DeathTimeHour.Size = new System.Drawing.Size(87, 21);
            this.DeathTimeHour.TabIndex = 3;
            // 
            // MobPictureBox
            // 
            this.MobPictureBox.Location = new System.Drawing.Point(7, 12);
            this.MobPictureBox.Name = "MobPictureBox";
            this.MobPictureBox.Size = new System.Drawing.Size(400, 200);
            this.MobPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MobPictureBox.TabIndex = 0;
            this.MobPictureBox.TabStop = false;
            // 
            // MobForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(414, 291);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeathTimeMinute);
            this.Controls.Add(this.DeathTimeHour);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DeathDate);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.DiedAtRadio);
            this.Controls.Add(this.JustDiedRadio);
            this.Controls.Add(this.MobPictureBox);
            this.MaximumSize = new System.Drawing.Size(430, 330);
            this.MinimumSize = new System.Drawing.Size(430, 330);
            this.Name = "MobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MobForm";
            this.Load += new System.EventHandler(this.MobForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MobPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MobPictureBox;
        private System.Windows.Forms.RadioButton JustDiedRadio;
        private System.Windows.Forms.RadioButton DiedAtRadio;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.DateTimePicker DeathDate;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DeathTimeMinute;
        private System.Windows.Forms.ComboBox DeathTimeHour;
    }
}