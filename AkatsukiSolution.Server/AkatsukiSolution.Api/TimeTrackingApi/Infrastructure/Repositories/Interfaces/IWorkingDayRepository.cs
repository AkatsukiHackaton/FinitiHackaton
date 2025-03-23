using TimeTrackingApi.ModelsDto;

namespace TimeTrackingApi.Infrastructure.Repositories.Interfaces
{
    public interface IWorkingDayRepository
    {
        Task<List<WorkingDayViewModel>> GetWorkingDays(int? userId);
        Task<int> Add(WorkingDayDto workingDay);
        Task Delete(int workingDayId);
        Task Edit(WorkingDayDto workingDay);
    }
}
