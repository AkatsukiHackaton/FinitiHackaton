using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTrackingApi.Enums;
using TimeTrackingApi.Infrastructure.Context;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly TimeTrackingDbContext _timeTrackingContext;
        public UserRepository(TimeTrackingDbContext timeTrackingContext)
        {
            _timeTrackingContext = timeTrackingContext;
        }

        [HttpGet]
        public async Task<List<User>> GetAllEmployees()
        {
            return await _timeTrackingContext
                .Users
                .Include(u => u.Role)
                .Where(u => u.Role.Name == RoleEnum.Employee.ToString())
                .ToListAsync();
        }
    }
}
