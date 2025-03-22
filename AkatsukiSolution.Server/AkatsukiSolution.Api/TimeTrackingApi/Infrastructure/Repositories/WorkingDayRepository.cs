using TimeTrackingApi.Infrastructure.Context;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Repositories
{
    public class WorkingDayRepository : IWorkingDayRepository
    {
        readonly TimeTrackingDbContext _timeTrackingContext;
        public WorkingDayRepository(TimeTrackingDbContext timeTrackingContext) 
        { 
            _timeTrackingContext = timeTrackingContext;
        }

        public List<WorkingDay> GetWorkingDays(int EmployeeId)
        {
            throw new NotImplementedException();
        }
    }
}
