using Api.Filters;
using Microsoft.AspNetCore.Mvc;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;

namespace TimeTrackingApi.Controllers
{
    [TypeFilter(typeof(ApiExceptionFilterAttribute))]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _userRepository.GetAllEmployees());
        }
    }
}
