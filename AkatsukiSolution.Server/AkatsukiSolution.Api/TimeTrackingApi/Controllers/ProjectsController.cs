using Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;

namespace TimeTrackingApi.Controllers
{
    [TypeFilter(typeof(ApiExceptionFilterAttribute))]
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IProjectRepository _projectRepository;
        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _projectRepository.GetAll());
        }
    }
}
