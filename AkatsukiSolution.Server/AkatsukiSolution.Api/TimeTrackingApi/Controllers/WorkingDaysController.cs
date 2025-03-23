using Api.Filters;
using Microsoft.AspNetCore.Mvc;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;
using TimeTrackingApi.ModelsDto;

namespace TimeTrackingApi.Controllers
{
    [TypeFilter(typeof(ApiExceptionFilterAttribute))]
    [Route("[controller]")]
    [ApiController]
    public class WorkingDaysController : ControllerBase
    {
        readonly IWorkingDayRepository _workingDayRepository;

        public WorkingDaysController(IWorkingDayRepository workingDayRepository)
        {
            _workingDayRepository = workingDayRepository;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetWorkingDays(int? userId)
        {
            return Ok(await _workingDayRepository.GetWorkingDays(userId));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] WorkingDayDto workingDay)
        {
            return Ok(await _workingDayRepository.Add(workingDay));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(_workingDayRepository.Delete(id));
        }

        [HttpPatch("edit")]
        public async Task<IActionResult> Edit([FromBody] WorkingDayDto workingDay)
        {
            return Ok(_workingDayRepository.Edit(workingDay));
        }
    }
}
