using System;
using Microsoft.EntityFrameworkCore;
using WorkFlow.Data;
using WorkFlow.Inerfaces;
using WorkFlow.Models;

namespace WorkFlow.Services
{
	public class WorkflowService : IWorkflowService
    {
        private readonly ApplicationDbContext _context;
        public WorkflowService(ApplicationDbContext context) => _context = context;

        public async Task<Workflow> CreateWorkflowAsync(Workflow workflow)
        {

            //if (workflow.Steps != null)
            //{
            //    foreach (var step in workflow.Steps)
            //    {
            //        step.Workflow = workflow; // attach parent object (optional)
            //    }
            //}

            _context.Workflows.Add(workflow);
            await _context.SaveChangesAsync();
            return workflow;
        }

        public async Task<Workflow> UpdatedWorkflowAsync(Guid Id, Workflow updatedWorkflow)
        {

            var workflow = await _context.Workflows
                             .Include(w => w.Steps)
                             .FirstOrDefaultAsync(w => w.Id == Id);

            // Update basic info
            workflow.Name = updatedWorkflow.Name;
            workflow.Description = updatedWorkflow.Description;
            workflow.Priority = updatedWorkflow.Priority;
            workflow.Status = updatedWorkflow.Status;
            workflow.UpdatedAt = DateTime.Now;

            // Remove existing steps
            _context.WorkflowSteps.RemoveRange(workflow.Steps);

            // Add updated steps
            workflow.Steps = updatedWorkflow.Steps.Select(s => new WorkflowStep
            {
                StepName = s.StepName,
                AssignedTo = s.AssignedTo,
                ActionType = s.ActionType,
                Description = s.Description ,
                EstimatedDuration = s.EstimatedDuration ,
                IsParallel = s.IsParallel,  
                NextStep = s.NextStep,
                RequiresValidation = s.RequiresValidation,
                WorkflowId = workflow.Id
            }).ToList();

            await _context.SaveChangesAsync();


            await _context.SaveChangesAsync();
            return workflow;
        }

        public async Task<Workflow> GetWorkflowByIdAsync(Guid id)
        {
            return await _context.Workflows.Include(w => w.Steps).FirstOrDefaultAsync(w => w.Id == id);
        }
    }
}

