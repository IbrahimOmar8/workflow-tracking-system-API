using System;
using WorkFlow.Data;
using WorkFlow.Inerfaces;
using WorkFlow.Models;

namespace WorkFlow.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ApplicationDbContext _context;

        public ValidationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateStepAsync(Process process, WorkflowStep step, string performer)
        {
            if (step.RequiresValidation == false)
                return true;

            // Simulate an external API call
            bool isValid = await SimulateExternalCheck(step, performer);

            // Log the validation result
            var log = new ValidationLog
            {
                ProcessId = process.Id,
                StepName = step.StepName,
                IsSuccessful = isValid,
                Message = isValid ? "Validation passed" : "Validation failed"
            };

            _context.ValidationLogs.Add(log);
            await _context.SaveChangesAsync();

            return isValid;
        }

        private async Task<bool> SimulateExternalCheck(WorkflowStep step, string performer)
        {
            await Task.Delay(200); // Simulate API delay

            // Example logic:
            return step.StepName != "Finance Approval" || performer.StartsWith("finance");
        }
    }
}