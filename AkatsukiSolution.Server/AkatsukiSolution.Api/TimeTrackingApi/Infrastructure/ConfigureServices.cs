using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.Infrastructure.Context;


namespace TimeTrackingApi.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
        {
            services.AddDbContext<TimeTrackingDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TimeTracking"),
                    builder => builder.MigrationsAssembly(typeof(TimeTrackingDbContext).Assembly.FullName)
                ).EnableSensitiveDataLogging()
            );

            services.AddScoped<ITimeTrackingDbContext>(provider =>
                provider.GetRequiredService<TimeTrackingDbContext>()
            );

            return services;
        }
    }
}
