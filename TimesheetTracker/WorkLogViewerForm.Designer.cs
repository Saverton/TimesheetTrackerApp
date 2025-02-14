namespace TimesheetTracker
{
	partial class WorkLogViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkLogViewerForm));
            DatePicker = new DateTimePicker();
            HoursWorkedTextBox = new TextBox();
            NotesTextBox = new RichTextBox();
            ProjectDisplayTextBox = new TextBox();
            SuspendLayout();
            // 
            // DatePicker
            // 
            DatePicker.CalendarFont = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DatePicker.CustomFormat = "ddd, MMM dd, yyyy";
            DatePicker.Enabled = false;
            DatePicker.Format = DateTimePickerFormat.Custom;
            DatePicker.Location = new Point(12, 52);
            DatePicker.Name = "DatePicker";
            DatePicker.Size = new Size(310, 42);
            DatePicker.TabIndex = 1;
            DatePicker.Value = new DateTime(2024, 5, 15, 11, 59, 1, 0);
            // 
            // HoursWorkedTextBox
            // 
            HoursWorkedTextBox.Enabled = false;
            HoursWorkedTextBox.Location = new Point(12, 100);
            HoursWorkedTextBox.Name = "HoursWorkedTextBox";
            HoursWorkedTextBox.PlaceholderText = "00:00:00";
            HoursWorkedTextBox.Size = new Size(310, 42);
            HoursWorkedTextBox.TabIndex = 2;
            HoursWorkedTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // NotesTextBox
            // 
            NotesTextBox.Enabled = false;
            NotesTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NotesTextBox.Location = new Point(12, 148);
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            NotesTextBox.Size = new Size(310, 225);
            NotesTextBox.TabIndex = 3;
            NotesTextBox.Text = "";
            // 
            // ProjectDisplayTextBox
            // 
            ProjectDisplayTextBox.Enabled = false;
            ProjectDisplayTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectDisplayTextBox.Location = new Point(12, 12);
            ProjectDisplayTextBox.Name = "ProjectDisplayTextBox";
            ProjectDisplayTextBox.PlaceholderText = "Project Name";
            ProjectDisplayTextBox.Size = new Size(310, 34);
            ProjectDisplayTextBox.TabIndex = 4;
            // 
            // WorkLogViewerForm
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 387);
            Controls.Add(ProjectDisplayTextBox);
            Controls.Add(NotesTextBox);
            Controls.Add(HoursWorkedTextBox);
            Controls.Add(DatePicker);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "WorkLogViewerForm";
            Text = "Work Log Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker DatePicker;
		private TextBox HoursWorkedTextBox;
        private RichTextBox NotesTextBox;
        private TextBox ProjectDisplayTextBox;
    }
}