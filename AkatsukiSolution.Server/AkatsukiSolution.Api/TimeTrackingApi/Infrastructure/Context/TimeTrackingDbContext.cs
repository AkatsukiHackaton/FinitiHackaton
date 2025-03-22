using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TimeTrackingApi.Infrastructure.Context.Configurations;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Context
{
    public class TimeTrackingDbContext : DbContext, ITimeTrackingDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        //public DbSet<EmployeeManager> EmployeeManagers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkingDay> WorkingDays { get; set; }

        public TimeTrackingDbContext(DbContextOptions<TimeTrackingDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingDayConfiguration());
        }
    }
}
