using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTrackerLibrary.Validation
{
    public class ProjectModelValidator : AbstractValidator<ProjectModel>
    {
        public ProjectModelValidator()
        {
            RuleFor(p => p.ProjectName)
                .NotEmpty().WithMessage("Project name is required.")
                .MaximumLength(50).WithMessage("Project name must be less than 50 characters.");

            RuleFor(p => p.ProjectNumber)
                .NotEmpty().WithMessage("Project number is required.")
                .Matches(@"\d{5}\.\d{3}").WithMessage("Project number format is invalid. Should follow format '00000.000'.");

            RuleFor(p => p.ProjectPhase)
                .Matches(@"\d{3}").WithMessage("Project phase format is invalid. Either remove it or follow format '000'.");
        }
    }
}
