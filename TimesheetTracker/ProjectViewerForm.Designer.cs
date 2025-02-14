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
            NotesTextBox = new RichTextBox();
            ProjectNameTextBox = new TextBox();
            ProjectNumberTextBox = new TextBox();
            SuspendLayout();
            // 
            // NotesTextBox
            // 
            NotesTextBox.Enabled = false;
            NotesTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NotesTextBox.Location = new Point(12, 100);
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            NotesTextBox.Size = new Size(310, 270);
            NotesTextBox.TabIndex = 4;
            NotesTextBox.Text = "";
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.Enabled = false;
            ProjectNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectNameTextBox.Location = new Point(12, 12);
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.Size = new Size(310, 34);
            ProjectNameTextBox.TabIndex = 5;
            // 
            // ProjectNumberTextBox
            // 
            ProjectNumberTextBox.Enabled = false;
            ProjectNumberTextBox.Location = new Point(12, 52);
            ProjectNumberTextBox.Name = "ProjectNumberTextBox";
            ProjectNumberTextBox.Size = new Size(310, 42);
            ProjectNumberTextBox.TabIndex = 6;
            // 
            // ProjectViewerForm
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(334, 383);
            Controls.Add(ProjectNumberTextBox);
            Controls.Add(ProjectNameTextBox);
            Controls.Add(NotesTextBox);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "ProjectViewerForm";
            Text = "Project Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox NotesTextBox;
        private TextBox ProjectNameTextBox;
        private TextBox ProjectNumberTextBox;
    }
}