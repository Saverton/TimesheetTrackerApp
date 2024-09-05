namespace TimesheetTracker
{
	partial class ProjectViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectViewerForm));
            ProjectNameLabel = new Label();
            ProjectNumberLabel = new Label();
            ProjectPhaseLabel = new Label();
            NotesTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // ProjectNameLabel
            // 
            ProjectNameLabel.AutoSize = true;
            ProjectNameLabel.Location = new Point(12, 9);
            ProjectNameLabel.Name = "ProjectNameLabel";
            ProjectNameLabel.Size = new Size(163, 30);
            ProjectNameLabel.TabIndex = 0;
            ProjectNameLabel.Text = "<project name>";
            // 
            // ProjectNumberLabel
            // 
            ProjectNumberLabel.AutoSize = true;
            ProjectNumberLabel.ForeColor = SystemColors.ControlDarkDark;
            ProjectNumberLabel.Location = new Point(12, 39);
            ProjectNumberLabel.Name = "ProjectNumberLabel";
            ProjectNumberLabel.Size = new Size(68, 30);
            ProjectNumberLabel.TabIndex = 1;
            ProjectNumberLabel.Text = "00000";
            // 
            // ProjectPhaseLabel
            // 
            ProjectPhaseLabel.AutoSize = true;
            ProjectPhaseLabel.ForeColor = SystemColors.ControlDarkDark;
            ProjectPhaseLabel.Location = new Point(273, 39);
            ProjectPhaseLabel.Name = "ProjectPhaseLabel";
            ProjectPhaseLabel.Size = new Size(46, 30);
            ProjectPhaseLabel.TabIndex = 2;
            ProjectPhaseLabel.Text = "000";
            ProjectPhaseLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // NotesTextBox
            // 
            NotesTextBox.Location = new Point(12, 72);
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            NotesTextBox.Size = new Size(310, 277);
            NotesTextBox.TabIndex = 4;
            NotesTextBox.Text = "";
            // 
            // ProjectViewerForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 361);
            Controls.Add(NotesTextBox);
            Controls.Add(ProjectPhaseLabel);
            Controls.Add(ProjectNumberLabel);
            Controls.Add(ProjectNameLabel);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "ProjectViewerForm";
            Text = "Project Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProjectNameLabel;
		private Label ProjectNumberLabel;
		private Label ProjectPhaseLabel;
        private RichTextBox NotesTextBox;
    }
}