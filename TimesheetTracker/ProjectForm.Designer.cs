namespace TimesheetTracker
{
	partial class ProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            ProjectNameLabel = new Label();
            ProjectNameTextBox = new TextBox();
            ProjectNumberTextBox = new TextBox();
            ProjectNumberLabel = new Label();
            ProjectPhaseTextBox = new TextBox();
            ProjectPhaseLabel = new Label();
            NotesLabel = new Label();
            SaveBtn = new Button();
            CancelBtn = new Button();
            NotesTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // ProjectNameLabel
            // 
            ProjectNameLabel.AutoSize = true;
            ProjectNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectNameLabel.ForeColor = SystemColors.ControlDarkDark;
            ProjectNameLabel.Location = new Point(12, 9);
            ProjectNameLabel.Name = "ProjectNameLabel";
            ProjectNameLabel.Size = new Size(104, 21);
            ProjectNameLabel.TabIndex = 0;
            ProjectNameLabel.Text = "Project Name";
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.Location = new Point(12, 33);
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.Size = new Size(310, 35);
            ProjectNameTextBox.TabIndex = 0;
            // 
            // ProjectNumberTextBox
            // 
            ProjectNumberTextBox.Location = new Point(12, 95);
            ProjectNumberTextBox.Name = "ProjectNumberTextBox";
            ProjectNumberTextBox.Size = new Size(176, 35);
            ProjectNumberTextBox.TabIndex = 1;
            // 
            // ProjectNumberLabel
            // 
            ProjectNumberLabel.AutoSize = true;
            ProjectNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectNumberLabel.ForeColor = SystemColors.ControlDarkDark;
            ProjectNumberLabel.Location = new Point(12, 71);
            ProjectNumberLabel.Name = "ProjectNumberLabel";
            ProjectNumberLabel.Size = new Size(120, 21);
            ProjectNumberLabel.TabIndex = 2;
            ProjectNumberLabel.Text = "Project Number";
            // 
            // ProjectPhaseTextBox
            // 
            ProjectPhaseTextBox.Location = new Point(194, 95);
            ProjectPhaseTextBox.Name = "ProjectPhaseTextBox";
            ProjectPhaseTextBox.Size = new Size(128, 35);
            ProjectPhaseTextBox.TabIndex = 2;
            // 
            // ProjectPhaseLabel
            // 
            ProjectPhaseLabel.AutoSize = true;
            ProjectPhaseLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectPhaseLabel.ForeColor = SystemColors.ControlDarkDark;
            ProjectPhaseLabel.Location = new Point(194, 71);
            ProjectPhaseLabel.Name = "ProjectPhaseLabel";
            ProjectPhaseLabel.Size = new Size(103, 21);
            ProjectPhaseLabel.TabIndex = 4;
            ProjectPhaseLabel.Text = "Project Phase";
            // 
            // NotesLabel
            // 
            NotesLabel.AutoSize = true;
            NotesLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NotesLabel.ForeColor = SystemColors.ControlDarkDark;
            NotesLabel.Location = new Point(12, 133);
            NotesLabel.Name = "NotesLabel";
            NotesLabel.Size = new Size(51, 21);
            NotesLabel.TabIndex = 10;
            NotesLabel.Text = "Notes";
            // 
            // SaveBtn
            // 
            SaveBtn.AutoSize = true;
            SaveBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SaveBtn.Location = new Point(256, 253);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(66, 40);
            SaveBtn.TabIndex = 4;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.AutoSize = true;
            CancelBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelBtn.Location = new Point(165, 253);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(85, 40);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // NotesTextBox
            // 
            NotesTextBox.Location = new Point(16, 157);
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            NotesTextBox.Size = new Size(306, 90);
            NotesTextBox.TabIndex = 3;
            NotesTextBox.Text = "";
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 305);
            Controls.Add(NotesTextBox);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Controls.Add(NotesLabel);
            Controls.Add(ProjectPhaseTextBox);
            Controls.Add(ProjectPhaseLabel);
            Controls.Add(ProjectNumberTextBox);
            Controls.Add(ProjectNumberLabel);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(ProjectNameLabel);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "ProjectForm";
            Text = "Add/Edit Project";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProjectNameLabel;
		private TextBox ProjectNameTextBox;
		private TextBox ProjectNumberTextBox;
		private Label ProjectNumberLabel;
		private TextBox ProjectPhaseTextBox;
		private Label ProjectPhaseLabel;
		private Label NotesLabel;
		private Button SaveBtn;
		private Button CancelBtn;
        private RichTextBox NotesTextBox;
    }
}