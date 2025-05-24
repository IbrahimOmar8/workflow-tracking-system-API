using System;
using Microsoft.EntityFrameworkCore;
using WorkFlow.Data;
using WorkFlow.DTOs;
using WorkFlow.Inerfaces;
using WorkFlow.Models;

namespace WorkFlow.Services
{
	public class ProcessService : IProcessService
	{
        private readonly ApplicationDbContext _context;
        private readonly IValidationService _validationService;

        public ProcessService(ApplicationDbContext context ,IValidationService validationService)
        {
            _context = context;
            _validationService = validationService;
        }


        public async Task<Process> StartProcessAsync(StartProcessRequestDto request)
        {
            var workflow = await _context.Workflows
                .Include(w => w.Steps)
                .FirstOrDefaultAsync(w => w.Id == request.WorkflowId);

            if (workflow == null) throw new Exception("Workflow not found");

            var process = new Process
            {
                WorkflowId = workflow.Id,
                Initiator = request.Initiator
            };

            _context.Processes.Add(process);
            await _context.SaveChangesAsync();
            return process;
        }

        public async Task<bool> ExecuteStepAsync(ExecuteStepRequestDto request)
        {
            var process = await _context.Processes
                .Include(p => p.Workflow)
                    .ThenInclude(w => w.Steps)
                .Include(p => p.Steps)
                .FirstOrDefaultAsync(p => p.Id == request.ProcessId);

            if (process == null) throw new Exception("Process not found");

            var step = process.Workflow.Steps.FirstOrDefault(s => s.StepName == request.StepName);
            if (step == null) throw new Exception("Invalid step");

            // Check if already executed
            if (process.Steps.Any(s => s.StepName == request.StepName))
                throw new Exception("Step already executed");

            // Simulate step 
            bool valid = await _validationService.ValidateStepAsync(process, step, request.PerformedBy);
            if (!valid) return false;

            var processStep = new ProcessStep
            {
                ProcessId = process.Id,
                StepName = request.StepName,
                PerformedBy = request.PerformedBy,
                Action = request.Action
            };

            _context.ProcessSteps.Add(processStep);

            // Mark as completed if next step is "Completed"
            if (step.NextStep == "Completed")
            {
                process.Status = "Completed";
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> SimulateExternalValidation()
        {
            await Task.Delay(100); // Simulate delay
            return true; // Or false to simulate rejection
        }

        public async Task<List<Process>> GetProcessesAsync(string? status, Guid? workflowId, string? assignedTo)
        {
            var query = _context.Processes
                .Include(p => p.Steps)
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(p => p.Status == status);

            if (workflowId.HasValue)
                query = query.Where(p => p.WorkflowId == workflowId.Value);

            if (!string.IsNullOrEmpty(assignedTo))
                query = query.Where(p => p.Steps.Any(s => s.PerformedBy == assignedTo));

            return await query.ToListAsync();
        }
    }
}

