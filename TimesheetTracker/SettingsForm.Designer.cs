namespace TimesheetTracker
{
	partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            TitleLabel = new Label();
            OpenOnStartupCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AccessibleRole = AccessibleRole.TitleBar;
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(330, 37);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Timesheet Tracker Settings";
            // 
            // OpenOnStartupCheckBox
            // 
            OpenOnStartupCheckBox.AutoSize = true;
            OpenOnStartupCheckBox.Location = new Point(12, 49);
            OpenOnStartupCheckBox.Name = "OpenOnStartupCheckBox";
            OpenOnStartupCheckBox.Size = new Size(238, 41);
            OpenOnStartupCheckBox.TabIndex = 0;
            OpenOnStartupCheckBox.Text = "Open On Startup";
            OpenOnStartupCheckBox.UseVisualStyleBackColor = true;
            OpenOnStartupCheckBox.CheckedChanged += OpenOnStartupCheckBox_CheckedChanged;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(351, 311);
            Controls.Add(OpenOnStartupCheckBox);
            Controls.Add(TitleLabel);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "SettingsForm";
            Text = "Settings";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
		private CheckBox OpenOnStartupCheckBox;
	}
}