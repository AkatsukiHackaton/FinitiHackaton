using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Context
{
    public interface ITimeTrackingDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<WorkingDay> WorkingDays { get; set; }
    }
}
