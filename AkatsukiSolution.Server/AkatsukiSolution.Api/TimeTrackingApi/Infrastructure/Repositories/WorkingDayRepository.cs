using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.Infrastructure.Context;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;
using TimeTrackingApi.Logger;
using TimeTrackingApi.Models;
using TimeTrackingApi.ModelsDto;

namespace TimeTrackingApi.Infrastructure.Repositories
{
    public class WorkingDayRepository : IWorkingDayRepository
    {
        readonly TimeTrackingDbContext _timeTrackingContext;
        readonly ITimeTrackingLogger _logger;
        public WorkingDayRepository(TimeTrackingDbContext timeTrackingContext, ITimeTrackingLogger logger)
        {
            _timeTrackingContext = timeTrackingContext;
            _logger = logger;
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
                throw new Exception("WorkingDayDto was null.");
            }

            var employee = await _timeTrackingContext.Users.FirstOrDefaultAsync(u => u.Id == workingDayDto.EmployeeId);
            var project = await _timeTrackingContext.Projects.FirstOrDefaultAsync(p => p.Id == workingDayDto.ProjectId);

            if (employee == null)
            {
                throw new Exception("User employee not found.");
            }

            if (project == null)
            {
                throw new Exception("Project record not found.");
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

            try
            {
                await _timeTrackingContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                _logger.Log(ex.Message);
                throw;
            }

            return workingDay.Id;
        }

        public async Task Delete(int workingDayId)
        {
            try
            {
                var workingDay = await _timeTrackingContext.WorkingDays.FirstOrDefaultAsync(wd => wd.Employee.Id == workingDayId);

                if (workingDay != null)
                {
                    _timeTrackingContext.WorkingDays.Remove(workingDay!);

                    await _timeTrackingContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
                throw;
            }
        }

        public async Task Edit(WorkingDayDto workingDayDto)
        {
            try
            { 
                var existingWorkingDay = await _timeTrackingContext.WorkingDays.FirstOrDefaultAsync(wd => wd.Id == workingDayDto.Id);

                if (existingWorkingDay != null)
                {
                    _timeTrackingContext.WorkingDays.Update(existingWorkingDay);

                    await _timeTrackingContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
                throw;
            }
        }
    }
}
