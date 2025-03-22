using TimeTrackingApi.Models;
using TimeTrackingApi.ModelsDto;

namespace TimeTrackingApi.Infrastructure.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
    }
}
