using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetTrackerLibrary.Models;

namespace TimesheetTrackerLibrary.DataAccess.EFCore
{
    public class EFCoreTimesheetDataAccess(TimesheetTrackerDbContext ctx) : ITimesheetDataAccess
    {
        private readonly TimesheetTrackerDbContext _ctx = ctx;

        public ProjectModel CreateProject(ProjectModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Notes))
            {
                model.Notes = null;
            }

            model.CreatedAt = model.UpdatedAt = DateTime.UtcNow;

            _ctx.Projects.Add(model);
            _ctx.SaveChanges();

            return model;
        }

        public List<ProjectModel> GetAllProjects(bool includeInactive = false) =>
            _ctx.Projects
                .Where(prj => includeInactive || prj.IsActive)
                .ToList();

        public WorkLogModel? GetWorkLog(int projectId, DateOnly date) =>
            _ctx.WorkLogs.FirstOrDefault(log => log.ProjectId == projectId && log.Date == date);

        public List<WorkLogModel> GetWorkLogsInDateRange(DateOnly startDate, DateOnly endDate)
        {
            var (startDateTime, endDateTime) = (new DateTime(startDate, TimeOnly.MinValue), new DateTime(endDate, TimeOnly.MaxValue));

            return _ctx.WorkLogs
                .Include(log => log.Project)
                .Where(log => log.CreatedAt >= startDateTime && log.CreatedAt <= endDateTime)
                .ToList();
        }

        public void UpdateProject(ProjectModel model)
        {
            var existing = _ctx.Projects.First(prj => prj.Id == model.Id);

            existing.ProjectName = model.ProjectName;
            existing.ProjectNumber = model.ProjectNumber;
            existing.ProjectPhase = model.ProjectPhase;
            existing.Notes = string.IsNullOrWhiteSpace(model.Notes) ? null : model.Notes;
            existing.UpdatedAt = DateTime.UtcNow;
            existing.IsActive = model.IsActive;

            _ctx.SaveChanges();
        }

        public void UpsertWorkLog(WorkLogModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Notes))
            {
                model.Notes = null;
            }

            var existing = _ctx.WorkLogs
                .FirstOrDefault(log => log.ProjectId == model.ProjectId && log.Date == model.Date);

            if (existing == null)
            {
                model.CreatedAt = model.UpdatedAt = DateTime.UtcNow;
                _ctx.WorkLogs.Add(model);
            }
            else
            {
                existing.HoursWorked = model.HoursWorked;
                existing.Notes = model.Notes;
                existing.UpdatedAt = DateTime.UtcNow;
            }

            _ctx.SaveChanges();
        }
    }
}
