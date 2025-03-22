using TimeTrackingApi.Infrastructure.Context;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Repositories
{
    public class WorkingDayRepository : IWorkingDayRepository
    {
        readonly TimeTrackingContext _timeTrackingContext;
        public WorkingDayRepository(TimeTrackingContext timeTrackingContext) 
        { 
            _timeTrackingContext = timeTrackingContext;
        }

        public List<WorkingDay> GetWorkingDays(int EmployeeId)
        {
            throw new NotImplementedException();
        }
    }
}
