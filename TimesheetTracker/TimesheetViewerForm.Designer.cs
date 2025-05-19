namespace TimesheetTracker
{
	partial class TimesheetViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimesheetViewerForm));
            TimesheetDataGrid = new DataGridView();
            YearComboBox = new ComboBox();
            YearLabel = new Label();
            WeekLabel = new Label();
            WeekComboBox = new ComboBox();
            DateTimeGeneratedLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)TimesheetDataGrid).BeginInit();
            SuspendLayout();
            // 
            // TimesheetDataGrid
            // 
            TimesheetDataGrid.AllowUserToAddRows = false;
            TimesheetDataGrid.AllowUserToDeleteRows = false;
            TimesheetDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TimesheetDataGrid.Location = new Point(12, 81);
            TimesheetDataGrid.Margin = new Padding(2);
            TimesheetDataGrid.Name = "TimesheetDataGrid";
            TimesheetDataGrid.ReadOnly = true;
            TimesheetDataGrid.RowHeadersWidth = 51;
            TimesheetDataGrid.Size = new Size(1459, 361);
            TimesheetDataGrid.TabIndex = 2;
            // 
            // YearComboBox
            // 
            YearComboBox.FormattingEnabled = true;
            YearComboBox.Location = new Point(12, 40);
            YearComboBox.Name = "YearComboBox";
            YearComboBox.Size = new Size(121, 36);
            YearComboBox.TabIndex = 0;
            YearComboBox.SelectedIndexChanged += YearComboBox_SelectedIndexChanged;
            // 
            // YearLabel
            // 
            YearLabel.AutoSize = true;
            YearLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            YearLabel.ForeColor = SystemColors.ControlDarkDark;
            YearLabel.Location = new Point(12, 9);
            YearLabel.Name = "YearLabel";
            YearLabel.Size = new Size(48, 28);
            YearLabel.TabIndex = 2;
            YearLabel.Text = "Year";
            // 
            // WeekLabel
            // 
            WeekLabel.AutoSize = true;
            WeekLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WeekLabel.ForeColor = SystemColors.ControlDarkDark;
            WeekLabel.Location = new Point(139, 9);
            WeekLabel.Name = "WeekLabel";
            WeekLabel.Size = new Size(60, 28);
            WeekLabel.TabIndex = 4;
            WeekLabel.Text = "Week";
            // 
            // WeekComboBox
            // 
            WeekComboBox.FormattingEnabled = true;
            WeekComboBox.Location = new Point(139, 40);
            WeekComboBox.Name = "WeekComboBox";
            WeekComboBox.Size = new Size(187, 36);
            WeekComboBox.TabIndex = 1;
            WeekComboBox.SelectedValueChanged += WeekComboBox_SelectedValueChanged;
            // 
            // DateTimeGeneratedLabel
            // 
            DateTimeGeneratedLabel.AutoSize = true;
            DateTimeGeneratedLabel.ForeColor = SystemColors.ControlDarkDark;
            DateTimeGeneratedLabel.Location = new Point(1149, 48);
            DateTimeGeneratedLabel.Name = "DateTimeGeneratedLabel";
            DateTimeGeneratedLabel.Size = new Size(321, 28);
            DateTimeGeneratedLabel.TabIndex = 5;
            DateTimeGeneratedLabel.Text = "generated at 00/00/0000 00:00 AM";
            DateTimeGeneratedLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // TimesheetViewerForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1482, 453);
            Controls.Add(DateTimeGeneratedLabel);
            Controls.Add(WeekLabel);
            Controls.Add(WeekComboBox);
            Controls.Add(YearLabel);
            Controls.Add(YearComboBox);
            Controls.Add(TimesheetDataGrid);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "TimesheetViewerForm";
            Text = "Timesheet Viewer";
            ((System.ComponentModel.ISupportInitialize)TimesheetDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView TimesheetDataGrid;
		private ComboBox YearComboBox;
		private Label YearLabel;
		private Label WeekLabel;
		private ComboBox WeekComboBox;
		private Label DateTimeGeneratedLabel;
	}
}