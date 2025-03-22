using Microsoft.EntityFrameworkCore;
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

        public async Task<int> Add(WorkingDay workingDay)
        {
            if (workingDay != null)
            {
                _timeTrackingContext.WorkingDays.Add(workingDay);

                await _timeTrackingContext.SaveChangesAsync();

                return workingDay.Id;
            }

            return 0;
        }

        public async Task Delete(int workingDayId)
        {
            var workingDay = _timeTrackingContext.WorkingDays.FirstOrDefaultAsync(wd => wd.Employee.Id == workingDayId).Result;

            if (workingDay != null)
            {
                _timeTrackingContext.WorkingDays.Remove(workingDay!);

                await _timeTrackingContext.SaveChangesAsync();   
            }          
        }

        public async Task Edit(WorkingDay workingDay)
        {
            var existingWorkingDay = _timeTrackingContext.WorkingDays.FirstOrDefaultAsync(wd => wd.Id == workingDay.Id);

            if (existingWorkingDay != null)
            {
                _timeTrackingContext.WorkingDays.Update(workingDay);

                await _timeTrackingContext.SaveChangesAsync();
            }
        }

        public async Task<List<WorkingDay>> GetByEmployId(int EmployeeId)
        {
            return await _timeTrackingContext.WorkingDays.Where(wd => wd.Employee.Id == EmployeeId).ToListAsync();
        }
    }
}
