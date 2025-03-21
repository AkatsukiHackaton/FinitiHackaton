﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackingApi.Infrastructure.Repositories.Interfaces;
using TimeTrackingApi.Models;

namespace TimeTrackingApi.Controllers
{
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
        public async Task<IActionResult> GetWorkingDays(int userId)
        {
            return Ok(await _workingDayRepository.GetWorkingDays(userId));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] WorkingDay workingDay)
        {
            return Ok(await _workingDayRepository.Add(workingDay));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(_workingDayRepository.Delete(id));
        }

        [HttpPatch("edit")]
        public async Task<IActionResult> Edit([FromBody] WorkingDay workingDay)
        {
            return Ok(_workingDayRepository.Edit(workingDay));
        }
    }
}
