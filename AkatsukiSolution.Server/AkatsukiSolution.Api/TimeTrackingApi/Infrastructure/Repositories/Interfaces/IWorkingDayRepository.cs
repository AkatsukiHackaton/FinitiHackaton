using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Repositories.Interfaces
{
    public interface IWorkingDayRepository
    {
        List<WorkingDay> GetWorkingDays(int EmployeeId);
    }
}
