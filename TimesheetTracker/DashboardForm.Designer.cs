namespace TimesheetTracker
{
	partial class DashboardForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            ProjectsComboBox = new ComboBox();
            AddProjectLink = new LinkLabel();
            EditProjectLink = new LinkLabel();
            TimerLabel = new Label();
            TimerControlBtn = new Button();
            SaveBtn = new Button();
            NotesLabel = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            workLogsToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            timesheetsToolStripMenuItem = new ToolStripMenuItem();
            Timer = new System.Windows.Forms.Timer(components);
            TimesheetTrackerMinimizeNotifyIcon = new NotifyIcon(components);
            NotesTextBox = new RichTextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ProjectsComboBox
            // 
            ProjectsComboBox.FormattingEnabled = true;
            ProjectsComboBox.Location = new Point(12, 38);
            ProjectsComboBox.Name = "ProjectsComboBox";
            ProjectsComboBox.Size = new Size(310, 44);
            ProjectsComboBox.TabIndex = 0;
            ProjectsComboBox.SelectedIndexChanged += ProjectsComboBox_SelectedValueChanged;
            // 
            // AddProjectLink
            // 
            AddProjectLink.AutoSize = true;
            AddProjectLink.Location = new Point(217, 79);
            AddProjectLink.Name = "AddProjectLink";
            AddProjectLink.Size = new Size(66, 37);
            AddProjectLink.TabIndex = 1;
            AddProjectLink.TabStop = true;
            AddProjectLink.Text = "Add";
            AddProjectLink.LinkClicked += AddProjectLink_LinkClicked;
            // 
            // EditProjectLink
            // 
            EditProjectLink.AutoSize = true;
            EditProjectLink.Location = new Point(274, 79);
            EditProjectLink.Name = "EditProjectLink";
            EditProjectLink.Size = new Size(63, 37);
            EditProjectLink.TabIndex = 2;
            EditProjectLink.TabStop = true;
            EditProjectLink.Text = "Edit";
            EditProjectLink.LinkClicked += EditProjectLink_LinkClicked;
            // 
            // TimerLabel
            // 
            TimerLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimerLabel.Location = new Point(12, 120);
            TimerLabel.Name = "TimerLabel";
            TimerLabel.Size = new Size(310, 45);
            TimerLabel.TabIndex = 3;
            TimerLabel.Text = "00:00";
            TimerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TimerControlBtn
            // 
            TimerControlBtn.Location = new Point(12, 181);
            TimerControlBtn.Name = "TimerControlBtn";
            TimerControlBtn.Size = new Size(310, 40);
            TimerControlBtn.TabIndex = 4;
            TimerControlBtn.Text = "Start / Stop";
            TimerControlBtn.UseVisualStyleBackColor = true;
            TimerControlBtn.Click += TimerControlBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.AutoSize = true;
            SaveBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SaveBtn.Enabled = false;
            SaveBtn.Location = new Point(256, 339);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(82, 47);
            SaveBtn.TabIndex = 7;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // NotesLabel
            // 
            NotesLabel.AutoSize = true;
            NotesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NotesLabel.ForeColor = SystemColors.ControlDarkDark;
            NotesLabel.Location = new Point(12, 224);
            NotesLabel.Name = "NotesLabel";
            NotesLabel.Size = new Size(64, 28);
            NotesLabel.TabIndex = 8;
            NotesLabel.Text = "Notes";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(334, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(145, 26);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(145, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { workLogsToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // workLogsToolStripMenuItem
            // 
            workLogsToolStripMenuItem.Name = "workLogsToolStripMenuItem";
            workLogsToolStripMenuItem.Size = new Size(161, 26);
            workLogsToolStripMenuItem.Text = "Work Logs";
            workLogsToolStripMenuItem.Click += workLogsToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { timesheetsToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(55, 24);
            viewToolStripMenuItem.Text = "View";
            // 
            // timesheetsToolStripMenuItem
            // 
            timesheetsToolStripMenuItem.Name = "timesheetsToolStripMenuItem";
            timesheetsToolStripMenuItem.Size = new Size(166, 26);
            timesheetsToolStripMenuItem.Text = "Timesheets";
            timesheetsToolStripMenuItem.Click += timesheetsToolStripMenuItem_Click;
            // 
            // Timer
            // 
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            // 
            // TimesheetTrackerMinimizeNotifyIcon
            // 
            TimesheetTrackerMinimizeNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            TimesheetTrackerMinimizeNotifyIcon.BalloonTipText = "The Timesheet Tracker app is running in the background.\r\n";
            TimesheetTrackerMinimizeNotifyIcon.BalloonTipTitle = "Application Minimized";
            TimesheetTrackerMinimizeNotifyIcon.Icon = (Icon)resources.GetObject("TimesheetTrackerMinimizeNotifyIcon.Icon");
            TimesheetTrackerMinimizeNotifyIcon.Text = "Timesheet Tracker";
            TimesheetTrackerMinimizeNotifyIcon.Visible = true;
            TimesheetTrackerMinimizeNotifyIcon.BalloonTipClicked += TimesheetTrackerMinimizeNotifyIcon_BalloonTipClicked;
            TimesheetTrackerMinimizeNotifyIcon.MouseDoubleClick += TimesheetTrackerMinimizeNotifyIcon_MouseDoubleClick;
            // 
            // NotesTextBox
            // 
            NotesTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NotesTextBox.Location = new Point(12, 248);
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            NotesTextBox.Size = new Size(310, 85);
            NotesTextBox.TabIndex = 5;
            NotesTextBox.Text = "";
            NotesTextBox.TextChanged += NotesTextBox_TextChanged;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 391);
            Controls.Add(NotesTextBox);
            Controls.Add(NotesLabel);
            Controls.Add(SaveBtn);
            Controls.Add(TimerControlBtn);
            Controls.Add(TimerLabel);
            Controls.Add(EditProjectLink);
            Controls.Add(AddProjectLink);
            Controls.Add(ProjectsComboBox);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 6, 5, 6);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Timesheet Tracker";
            FormClosing += DashboardForm_FormClosing;
            KeyDown += DashboardForm_KeyDown;
            Resize += DashboardForm_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ProjectsComboBox;
		private LinkLabel AddProjectLink;
		private LinkLabel EditProjectLink;
		private Label TimerLabel;
		private Button TimerControlBtn;
		private Button SaveBtn;
		private Label NotesLabel;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem settingsToolStripMenuItem;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem workLogsToolStripMenuItem;
		private ToolStripMenuItem viewToolStripMenuItem;
		private ToolStripMenuItem timesheetsToolStripMenuItem;
		private System.Windows.Forms.Timer Timer;
		private NotifyIcon TimesheetTrackerMinimizeNotifyIcon;
        private RichTextBox NotesTextBox;
    }
}
