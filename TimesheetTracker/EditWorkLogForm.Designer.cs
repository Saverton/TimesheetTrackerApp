namespace TimesheetTracker
{
	partial class EditWorkLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditWorkLogForm));
            DayLabel = new Label();
            ProjectLabel = new Label();
            ProjectComboBox = new ComboBox();
            WorkLogGroupBox = new GroupBox();
            NotesTextBox = new RichTextBox();
            HoursWorkedTextBox = new TextBox();
            SaveBtn = new Button();
            NotesLabel = new Label();
            HoursWorkedLabel = new Label();
            DatePicker = new DateTimePicker();
            WorkLogGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // DayLabel
            // 
            DayLabel.AutoSize = true;
            DayLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DayLabel.ForeColor = SystemColors.ControlDarkDark;
            DayLabel.Location = new Point(12, 9);
            DayLabel.Name = "DayLabel";
            DayLabel.Size = new Size(37, 21);
            DayLabel.TabIndex = 3;
            DayLabel.Text = "Day";
            // 
            // ProjectLabel
            // 
            ProjectLabel.AutoSize = true;
            ProjectLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectLabel.ForeColor = SystemColors.ControlDarkDark;
            ProjectLabel.Location = new Point(12, 73);
            ProjectLabel.Name = "ProjectLabel";
            ProjectLabel.Size = new Size(58, 21);
            ProjectLabel.TabIndex = 6;
            ProjectLabel.Text = "Project";
            // 
            // ProjectComboBox
            // 
            ProjectComboBox.Enabled = false;
            ProjectComboBox.FormattingEnabled = true;
            ProjectComboBox.Location = new Point(12, 97);
            ProjectComboBox.Name = "ProjectComboBox";
            ProjectComboBox.Size = new Size(310, 38);
            ProjectComboBox.TabIndex = 1;
            ProjectComboBox.SelectedValueChanged += ProjectComboBox_SelectedValueChanged;
            // 
            // WorkLogGroupBox
            // 
            WorkLogGroupBox.Controls.Add(NotesTextBox);
            WorkLogGroupBox.Controls.Add(HoursWorkedTextBox);
            WorkLogGroupBox.Controls.Add(SaveBtn);
            WorkLogGroupBox.Controls.Add(NotesLabel);
            WorkLogGroupBox.Controls.Add(HoursWorkedLabel);
            WorkLogGroupBox.Enabled = false;
            WorkLogGroupBox.Location = new Point(12, 141);
            WorkLogGroupBox.Name = "WorkLogGroupBox";
            WorkLogGroupBox.Size = new Size(310, 316);
            WorkLogGroupBox.TabIndex = 9;
            WorkLogGroupBox.TabStop = false;
            WorkLogGroupBox.Text = "Work Log";
            // 
            // NotesTextBox
            // 
            NotesTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NotesTextBox.Location = new Point(6, 123);
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            NotesTextBox.Size = new Size(298, 141);
            NotesTextBox.TabIndex = 3;
            NotesTextBox.Text = "";
            // 
            // HoursWorkedTextBox
            // 
            HoursWorkedTextBox.Location = new Point(6, 61);
            HoursWorkedTextBox.MaxLength = 5;
            HoursWorkedTextBox.Name = "HoursWorkedTextBox";
            HoursWorkedTextBox.PlaceholderText = "hh:mm";
            HoursWorkedTextBox.Size = new Size(298, 35);
            HoursWorkedTextBox.TabIndex = 2;
            HoursWorkedTextBox.KeyPress += HoursWorkedTextBox_KeyPress;
            // 
            // SaveBtn
            // 
            SaveBtn.AutoSize = true;
            SaveBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SaveBtn.Location = new Point(238, 270);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(66, 40);
            SaveBtn.TabIndex = 4;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // NotesLabel
            // 
            NotesLabel.AutoSize = true;
            NotesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NotesLabel.ForeColor = SystemColors.ControlDarkDark;
            NotesLabel.Location = new Point(6, 99);
            NotesLabel.Name = "NotesLabel";
            NotesLabel.Size = new Size(51, 21);
            NotesLabel.TabIndex = 10;
            NotesLabel.Text = "Notes";
            // 
            // HoursWorkedLabel
            // 
            HoursWorkedLabel.AutoSize = true;
            HoursWorkedLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HoursWorkedLabel.ForeColor = SystemColors.ControlDarkDark;
            HoursWorkedLabel.Location = new Point(6, 37);
            HoursWorkedLabel.Name = "HoursWorkedLabel";
            HoursWorkedLabel.Size = new Size(110, 21);
            HoursWorkedLabel.TabIndex = 4;
            HoursWorkedLabel.Text = "Hours Worked";
            // 
            // DatePicker
            // 
            DatePicker.Checked = false;
            DatePicker.CustomFormat = "ddd, MMM dd, yyyy";
            DatePicker.Format = DateTimePickerFormat.Custom;
            DatePicker.Location = new Point(12, 33);
            DatePicker.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            DatePicker.Name = "DatePicker";
            DatePicker.Size = new Size(310, 35);
            DatePicker.TabIndex = 0;
            DatePicker.ValueChanged += DatePicker_ValueChanged;
            // 
            // EditWorkLogForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 469);
            Controls.Add(DatePicker);
            Controls.Add(WorkLogGroupBox);
            Controls.Add(ProjectLabel);
            Controls.Add(ProjectComboBox);
            Controls.Add(DayLabel);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "EditWorkLogForm";
            Text = "Edit Work Log";
            WorkLogGroupBox.ResumeLayout(false);
            WorkLogGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DayLabel;
		private Label ProjectLabel;
		private ComboBox ProjectComboBox;
		private GroupBox WorkLogGroupBox;
		private TextBox EndTimeTextBox;
		private Label EndTimeLabel;
		private TextBox StartTimeTextBox;
		private Label HoursWorkedLabel;
		private Label NotesLabel;
		private Button SaveBtn;
		private TextBox HoursWorkedTextBox;
		private DateTimePicker DatePicker;
        private RichTextBox NotesTextBox;
    }
}