using TimesheetTrackerLibrary.Models;

namespace TimesheetTrackerLibrary.DataAccess
{
    public interface ITimesheetDataAccess
    {
        ProjectModel CreateProject(ProjectModel model);
        List<ProjectModel> GetAllProjects();
        WorkLogModel? GetWorkLog(int projectId, DateOnly date);
        List<WorkLogModel> GetWorkLogsInDateRange(DateOnly startDate, DateOnly endDate);
        void UpdateProject(ProjectModel model);
        WorkLogModel UpsertWorkLog(WorkLogModel model);
    }
}