using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Context
{
    public interface ITimeTrackingDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Manager> Managers { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<WorkingDay> WorkingDays { get; set; }
    }
}
