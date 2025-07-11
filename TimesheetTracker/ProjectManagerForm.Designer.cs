namespace TimesheetTracker
{
    partial class ProjectManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectManagerForm));
            label1 = new Label();
            ProjectsListBox = new ListBox();
            ProjectFormPanel = new Panel();
            CreatedUpdatedLabel = new Label();
            SaveButton = new Button();
            ActiveCheckBox = new CheckBox();
            NotesTextBox = new TextBox();
            label5 = new Label();
            ProjectPhaseTextBox = new TextBox();
            ProjectNumberTextBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            ProjectNameTextBox = new TextBox();
            label2 = new Label();
            AddProjectButton = new Button();
            ProjectFormPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(133, 45);
            label1.TabIndex = 0;
            label1.Text = "Projects";
            // 
            // ProjectsListBox
            // 
            ProjectsListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectsListBox.FormattingEnabled = true;
            ProjectsListBox.ItemHeight = 32;
            ProjectsListBox.Location = new Point(13, 61);
            ProjectsListBox.Margin = new Padding(4, 2, 4, 2);
            ProjectsListBox.Name = "ProjectsListBox";
            ProjectsListBox.Size = new Size(440, 580);
            ProjectsListBox.TabIndex = 1;
            ProjectsListBox.SelectedValueChanged += ProjectsListBox_SelectedValueChanged;
            // 
            // ProjectFormPanel
            // 
            ProjectFormPanel.Controls.Add(CreatedUpdatedLabel);
            ProjectFormPanel.Controls.Add(SaveButton);
            ProjectFormPanel.Controls.Add(ActiveCheckBox);
            ProjectFormPanel.Controls.Add(NotesTextBox);
            ProjectFormPanel.Controls.Add(label5);
            ProjectFormPanel.Controls.Add(ProjectPhaseTextBox);
            ProjectFormPanel.Controls.Add(ProjectNumberTextBox);
            ProjectFormPanel.Controls.Add(label4);
            ProjectFormPanel.Controls.Add(label3);
            ProjectFormPanel.Controls.Add(ProjectNameTextBox);
            ProjectFormPanel.Controls.Add(label2);
            ProjectFormPanel.Location = new Point(461, 61);
            ProjectFormPanel.Margin = new Padding(4, 2, 4, 2);
            ProjectFormPanel.Name = "ProjectFormPanel";
            ProjectFormPanel.Size = new Size(411, 592);
            ProjectFormPanel.TabIndex = 2;
            // 
            // CreatedUpdatedLabel
            // 
            CreatedUpdatedLabel.AutoSize = true;
            CreatedUpdatedLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreatedUpdatedLabel.ForeColor = SystemColors.ControlDarkDark;
            CreatedUpdatedLabel.Location = new Point(4, 501);
            CreatedUpdatedLabel.Name = "CreatedUpdatedLabel";
            CreatedUpdatedLabel.Size = new Size(153, 32);
            CreatedUpdatedLabel.TabIndex = 10;
            CreatedUpdatedLabel.Text = "(new project)";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(4, 540);
            SaveButton.Margin = new Padding(4, 2, 4, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(401, 50);
            SaveButton.TabIndex = 9;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ActiveCheckBox
            // 
            ActiveCheckBox.AutoSize = true;
            ActiveCheckBox.Location = new Point(4, 457);
            ActiveCheckBox.Margin = new Padding(4, 2, 4, 2);
            ActiveCheckBox.Name = "ActiveCheckBox";
            ActiveCheckBox.Size = new Size(149, 49);
            ActiveCheckBox.TabIndex = 8;
            ActiveCheckBox.Text = "Active?";
            ActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // NotesTextBox
            // 
            NotesTextBox.Location = new Point(4, 215);
            NotesTextBox.Margin = new Padding(4, 2, 4, 2);
            NotesTextBox.Multiline = true;
            NotesTextBox.Name = "NotesTextBox";
            NotesTextBox.Size = new Size(402, 237);
            NotesTextBox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 174);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(106, 45);
            label5.TabIndex = 6;
            label5.Text = "Notes";
            // 
            // ProjectPhaseTextBox
            // 
            ProjectPhaseTextBox.Location = new Point(270, 128);
            ProjectPhaseTextBox.Margin = new Padding(4, 2, 4, 2);
            ProjectPhaseTextBox.Name = "ProjectPhaseTextBox";
            ProjectPhaseTextBox.PlaceholderText = "000";
            ProjectPhaseTextBox.Size = new Size(135, 51);
            ProjectPhaseTextBox.TabIndex = 5;
            ProjectPhaseTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // ProjectNumberTextBox
            // 
            ProjectNumberTextBox.Location = new Point(4, 128);
            ProjectNumberTextBox.Margin = new Padding(4, 2, 4, 2);
            ProjectNumberTextBox.Name = "ProjectNumberTextBox";
            ProjectNumberTextBox.PlaceholderText = "00000.000";
            ProjectNumberTextBox.Size = new Size(261, 51);
            ProjectNumberTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(313, 87);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(105, 45);
            label4.TabIndex = 3;
            label4.Text = "Phase";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 87);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(247, 45);
            label3.TabIndex = 2;
            label3.Text = "Project Number";
            // 
            // ProjectNameTextBox
            // 
            ProjectNameTextBox.Location = new Point(4, 41);
            ProjectNameTextBox.Margin = new Padding(4, 2, 4, 2);
            ProjectNameTextBox.Name = "ProjectNameTextBox";
            ProjectNameTextBox.Size = new Size(402, 51);
            ProjectNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(215, 45);
            label2.TabIndex = 0;
            label2.Text = "Project Name";
            // 
            // AddProjectButton
            // 
            AddProjectButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddProjectButton.Location = new Point(390, 20);
            AddProjectButton.Name = "AddProjectButton";
            AddProjectButton.Size = new Size(66, 36);
            AddProjectButton.TabIndex = 3;
            AddProjectButton.Text = "Add";
            AddProjectButton.UseVisualStyleBackColor = true;
            AddProjectButton.Click += AddProjectButton_Click;
            // 
            // ProjectManagerForm
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 703);
            Controls.Add(AddProjectButton);
            Controls.Add(ProjectFormPanel);
            Controls.Add(ProjectsListBox);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6, 7, 6, 7);
            Name = "ProjectManagerForm";
            Text = "Add/Edit Project";
            FormClosing += ProjectManagerForm_FormClosing;
            ProjectFormPanel.ResumeLayout(false);
            ProjectFormPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox ProjectsListBox;
        private Panel ProjectFormPanel;
        private Label label4;
        private Label label3;
        private TextBox ProjectNameTextBox;
        private Label label2;
        private Button SaveButton;
        private CheckBox ActiveCheckBox;
        private TextBox NotesTextBox;
        private Label label5;
        private TextBox ProjectPhaseTextBox;
        private TextBox ProjectNumberTextBox;
        private Button AddProjectButton;
        private Label CreatedUpdatedLabel;
    }
}