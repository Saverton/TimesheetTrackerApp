using TimesheetTrackerLibrary.Models;

namespace TimesheetTracker
{
    public partial class ProjectViewerForm : Form
    {
        public ProjectViewerForm(ProjectModel project)
        {
            InitializeComponent();

            ProjectNameTextBox.Text = project.ProjectName;
            ProjectNumberTextBox.Text = project.ProjectNumberPhase;
            NotesTextBox.Text = project.Notes ?? "(no notes)";
        }
    }
}
