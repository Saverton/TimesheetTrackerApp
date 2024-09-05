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
            ProjectLabel = new Label();
            DatePicker = new DateTimePicker();
            HoursWorkedTextBox = new TextBox();
            NotesTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // ProjectLabel
            // 
            ProjectLabel.AccessibleRole = AccessibleRole.TitleBar;
            ProjectLabel.AutoEllipsis = true;
            ProjectLabel.AutoSize = true;
            ProjectLabel.Location = new Point(12, 9);
            ProjectLabel.Name = "ProjectLabel";
            ProjectLabel.Size = new Size(216, 30);
            ProjectLabel.TabIndex = 0;
            ProjectLabel.Text = "<project> (00000.000)";
            // 
            // DatePicker
            // 
            DatePicker.CalendarFont = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DatePicker.CustomFormat = "ddd, MMM dd, yyyy";
            DatePicker.Enabled = false;
            DatePicker.Format = DateTimePickerFormat.Custom;
            DatePicker.Location = new Point(12, 42);
            DatePicker.Name = "DatePicker";
            DatePicker.Size = new Size(310, 35);
            DatePicker.TabIndex = 1;
            DatePicker.Value = new DateTime(2024, 5, 15, 11, 59, 1, 0);
            // 
            // HoursWorkedTextBox
            // 
            HoursWorkedTextBox.Enabled = false;
            HoursWorkedTextBox.Location = new Point(12, 83);
            HoursWorkedTextBox.Name = "HoursWorkedTextBox";
            HoursWorkedTextBox.Size = new Size(310, 35);
            HoursWorkedTextBox.TabIndex = 2;
            HoursWorkedTextBox.Text = "00:00";
            HoursWorkedTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // NotesTextBox
            // 
            NotesTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NotesTextBox.Location = new Point(12, 124);
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            NotesTextBox.Size = new Size(310, 225);
            NotesTextBox.TabIndex = 3;
            NotesTextBox.Text = "";
            // 
            // WorkLogViewerForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 361);
            Controls.Add(NotesTextBox);
            Controls.Add(HoursWorkedTextBox);
            Controls.Add(DatePicker);
            Controls.Add(ProjectLabel);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "WorkLogViewerForm";
            Text = "Work Log Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProjectLabel;
		private DateTimePicker DatePicker;
		private TextBox HoursWorkedTextBox;
        private RichTextBox NotesTextBox;
    }
}