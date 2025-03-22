using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Repositories.Interfaces
{
    public interface IWorkingDayRepository
    {
        Task<List<WorkingDay>> GetWorkingDays(int userId);
        Task<int> Add(WorkingDay workingDay);
        Task Delete(int workingDayId);
        Task Edit(WorkingDay workingDay);
    }
}
