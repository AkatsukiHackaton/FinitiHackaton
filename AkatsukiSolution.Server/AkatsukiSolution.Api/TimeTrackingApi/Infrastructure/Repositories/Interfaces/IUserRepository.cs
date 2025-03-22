using TimeTrackingApi.Models;

namespace TimeTrackingApi.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllEmployees();
    }
}
