using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;

namespace TimeTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingDaysController : ControllerBase
    {
        readonly IWorkingDayRepository _workingDayRepository;

        public WorkingDaysController(IWorkingDayRepository workingDayRepository)
        {
            _workingDayRepository = workingDayRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkingDays(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
