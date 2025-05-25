using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Inerfaces;
using Application.DTOs;
using Infrastructure.Data;

namespace WorkFlow.Controllers
{
    [ApiController]
    [Route("v1/processes")]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> Start([FromBody] StartProcessRequestDto request)
        {
            var process = await _processService.StartProcessAsync(request);
            return Ok(process);
        }

        [HttpPost("execute")]
        public async Task<IActionResult> Execute([FromBody] ExecuteStepRequestDto request)
        {
            var success = await _processService.ExecuteStepAsync(request);
            if (!success) return BadRequest("Step validation failed.");
            return Ok("Step executed.");
        }

        [HttpGet]
        public async Task<IActionResult> GetProcesses([FromQuery] string? status, [FromQuery] Guid? workflowId, [FromQuery] string? assignedTo)
        {
            var processes = await _processService.GetProcessesAsync(status, workflowId, assignedTo);
            return Ok(processes);
        }


        [HttpGet("validations")]
        public async Task<IActionResult> GetValidationLogs([FromServices] ApplicationDbContext context)
        {
            var logs = await context.ValidationLogs.ToListAsync();
            return Ok(logs);
        }
    }
}

