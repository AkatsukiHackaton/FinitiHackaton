using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.Infrastructure.Context;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;
using TimeTrackingApi.Models;
using TimeTrackingApi.ModelsDto;

namespace TimeTrackingApi.Infrastructure.Repositories
{
    public class WorkingDayRepository : IWorkingDayRepository
    {
        readonly TimeTrackingDbContext _timeTrackingContext;
        public WorkingDayRepository(TimeTrackingDbContext timeTrackingContext)
        {
            _timeTrackingContext = timeTrackingContext;
        }

        public async Task<List<WorkingDayViewModel>> GetWorkingDays(int? userId)
        {
            return await _timeTrackingContext.WorkingDays
                .Where(wd => userId == null || wd.Employee.Id == userId)
                .Select(wd => new WorkingDayViewModel
                {
                    Id = wd.Id,
                    Date = wd.Date,
                    TaskDescription = wd.TaskDescription,
                    Hours = wd.Hours,
                    EmployeeFullName = $"{wd.Employee.FirstName} {wd.Employee.LastName}",
                    ProjectName = wd.Project.Name,
                })
                .ToListAsync();
        }

        public async Task<int> Add(WorkingDayDto workingDayDto)
        {
            if (workingDayDto == null)
            {
                return 0;
            }

            var employee = await _timeTrackingContext.Users.FirstOrDefaultAsync(u => u.Id == workingDayDto.EmployeeId);
            var project = await _timeTrackingContext.Projects.FirstOrDefaultAsync(p => p.Id == workingDayDto.ProjectId);

            if (employee == null || project == null)
            {
                return 0;
            }

            var workingDay = new WorkingDay
            {
                Date = workingDayDto.Date,
                TaskDescription = workingDayDto.TaskDescription,
                Hours = workingDayDto.Hours,
            };
            workingDay.Employee = employee;
            workingDay.Project = project;

            _timeTrackingContext.WorkingDays.Add(workingDay);

            await _timeTrackingContext.SaveChangesAsync();

            return workingDay.Id;
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

        public async Task Edit(WorkingDayDto workingDayDto)
        {
            var existingWorkingDay = _timeTrackingContext.WorkingDays.FirstOrDefaultAsync(wd => wd.Id == workingDayDto.Id).Result;

            if (existingWorkingDay != null)
            {
                _timeTrackingContext.WorkingDays.Update(existingWorkingDay);

                await _timeTrackingContext.SaveChangesAsync();
            }
        }
    }
}
