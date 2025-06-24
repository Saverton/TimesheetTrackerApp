using TimesheetTrackerLibrary.Models;

namespace TimesheetTrackerLibrary.DataAccess
{
    public interface ITimesheetDataAccess
    {
        ProjectModel CreateProject(ProjectModel model);
        List<ProjectModel> GetAllProjects(bool includeInactive = false);
        WorkLogModel? GetWorkLog(int projectId, DateOnly date);
        List<WorkLogModel> GetWorkLogsInDateRange(DateOnly startDate, DateOnly endDate);
        void UpdateProject(ProjectModel model);
        void UpsertWorkLog(WorkLogModel model);
        void UpsertPunchLog(PunchLogModel model);
    }
}