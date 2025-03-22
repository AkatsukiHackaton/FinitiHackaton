using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Repositories.Interfaces
{
    public interface IWorkingDayRepository
    {
        Task<List<WorkingDay>> GetByEmployId(int EmployeeId);
        Task<int> Add(WorkingDay workingDay);
        Task Delete(int workingDayId);
        Task Edit(WorkingDay workingDay);
    }
}
