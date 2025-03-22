using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Reflection.Metadata;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Context
{
    public class TimeTrackingContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkingDay> WorkingDays { get; set; }

        public TimeTrackingContext(DbContextOptions options) : base(options)
        {
           
        }
    }
}
