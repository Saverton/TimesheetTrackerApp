using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimesheetTrackerLibrary.DataAccess;
using TimesheetTrackerLibrary.DataAccess.Dapper;
using TimesheetTrackerLibrary.Models;
using TimesheetTrackerLibrary.Validation;

namespace TimesheetTracker
{
    public partial class ProjectManagerForm : Form
    {
        private readonly ITimesheetDataAccess _dataAccess;
        private BindingList<ProjectModel> _projects;
        private ProjectModel? _selectedProject;

        public delegate void DoneEditingHandler(object? sender, EventArgs args);
        public event DoneEditingHandler? DoneEditing;

        public ProjectManagerForm(ITimesheetDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            InitializeComponent();

            _projects = [.. _dataAccess.GetAllProjects(includeInactive: true)];

            WireUpLists();

            ProjectFormPanel.Visible = false;
        }

        private void WireUpLists()
        {
            ProjectsListBox.DataSource = _projects;
            ProjectsListBox.DisplayMember = nameof(ProjectModel.FullDisplay);
        }

        private void ProjectsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var prevSelectedProject = _selectedProject;
            if (prevSelectedProject != null && prevSelectedProject.Id == 0)
            {
                // remove unsaved new project
                _projects.Remove(prevSelectedProject);
            }

            _selectedProject = ProjectsListBox.SelectedItem as ProjectModel;

            if (_selectedProject == null)
            {
                ProjectFormPanel.Visible = false;
            }
            else
            {
                ProjectNameTextBox.Text = _selectedProject.ProjectName;
                ProjectNumberTextBox.Text = _selectedProject.ProjectNumber;
                ProjectPhaseTextBox.Text = _selectedProject.ProjectPhase ?? string.Empty;
                NotesTextBox.Text = _selectedProject.Notes;
                ActiveCheckBox.Checked = _selectedProject.IsActive;

                if (_selectedProject.Id == 0)
                {
                    CreatedUpdatedLabel.Text = "Not yet saved.";
                }
                else
                {
                    CreatedUpdatedLabel.Text = $"Saved at {_selectedProject.UpdatedAt.ToLocalTime():hh:mm:ss tt MM/dd/yy}.";
                }

                ProjectFormPanel.Visible = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_selectedProject == null)
            {
                return;
            }

            ProjectModel edited = new()
            {
                Id = _selectedProject.Id,
                ProjectName = ProjectNameTextBox.Text,
                ProjectNumber = ProjectNumberTextBox.Text,
                ProjectPhase = string.IsNullOrWhiteSpace(ProjectPhaseTextBox.Text)
                    ? null : ProjectPhaseTextBox.Text,
                Notes = NotesTextBox.Text,
                IsActive = ActiveCheckBox.Checked
            };

            // Validate
            var validator = new ProjectModelValidator();
            ValidationResult result = validator.Validate(edited);

            if (result.IsValid == false)
            {
                var errorMessage = string.Join(" ", result.Errors.Select(e => e.ErrorMessage));
                MessageBox.Show(
                    errorMessage,
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // save to database
            if (edited.Id == 0)
            {
                edited = _dataAccess.CreateProject(edited);
                _selectedProject.CreatedAt = edited.CreatedAt;
                _selectedProject.UpdatedAt = edited.UpdatedAt;
            }
            else
            {
                _dataAccess.UpdateProject(edited);
            }

            _selectedProject.Id = edited.Id;
            _selectedProject.ProjectName = edited.ProjectName;
            _selectedProject.ProjectNumber = edited.ProjectNumber;
            _selectedProject.ProjectPhase = edited.ProjectPhase;
            _selectedProject.Notes = edited.Notes;
            _selectedProject.IsActive = edited.IsActive;

            CreatedUpdatedLabel.Text = $"Saved at {_selectedProject.UpdatedAt.ToLocalTime():hh:mm:ss tt MM/dd/yy}.";

            _projects.ResetBindings();
        }

        private void AddProjectButton_Click(object sender, EventArgs e)
        {
            var newProject = new ProjectModel
            {
                ProjectName = "New Project"
            };

            _projects.Add(newProject);
            var newIdx = _projects.IndexOf(newProject);
            ProjectsListBox.SetSelected(newIdx, true);
        }

        private void ProjectManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoneEditing?.Invoke(this, EventArgs.Empty);
        }
    }
}
