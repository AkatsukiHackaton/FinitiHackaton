using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Context
{
    public interface ITimeTrackingDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<WorkingDay> WorkingDays { get; set; }
    }
}
