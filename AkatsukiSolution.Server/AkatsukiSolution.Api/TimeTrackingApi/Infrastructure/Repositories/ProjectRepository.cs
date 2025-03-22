using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.Infrastructure.Context;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;
using TimeTrackingApi.Models;
using TimeTrackingApi.ModelsDto;

namespace TimeTrackingApi.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private ITimeTrackingDbContext _context;

        public ProjectRepository(ITimeTrackingDbContext context)
        {
            this._context = context;
        }
        public Task<List<Project>> GetAll()
        {
            var projects = _context.Projects.Select(x => x).ToListAsync();
            return projects;
        }
    }
}
