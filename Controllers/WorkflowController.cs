using System;
using Microsoft.AspNetCore.Mvc;
using Application.Inerfaces;
using Domain.Models;

namespace WorkFlow.Controllers
{
    [ApiController]
    [Route("v1/workflows")]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;

        public WorkflowController(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateWorkflow([FromBody] Workflow workflow)
        {
            var result = await _workflowService.CreateWorkflowAsync(workflow);
              return CreatedAtAction(nameof(GetWorkflow), new { id = result.Id }, result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CreateWorkflow(Guid Id , [FromBody] Workflow workflow)
        {
            var result = await _workflowService.UpdatedWorkflowAsync(Id,workflow);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetWorkflow()
        {
            var result = await _workflowService.GetWorkflows();
            if (result == null) return NotFound();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkflow(Guid id)
        {
            var result = await _workflowService.GetWorkflowByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}

