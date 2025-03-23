using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.Infrastructure;
using TimeTrackingApi.Infrastructure.Context;
using TimeTrackingApi.Infrastructure.Repositories;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;
using TimeTrackingApi.Logger;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddTransient<IWorkingDayRepository, WorkingDayRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITimeTrackingLogger, TimeTrackingLogger>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TimeTrackingDbContext>();
    await context.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
