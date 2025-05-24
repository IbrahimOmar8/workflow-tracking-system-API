using System;
using WorkFlow.Models;

namespace WorkFlow.Inerfaces
{
	public interface IValidationService
	{
        Task<bool> ValidateStepAsync(Process process, WorkflowStep step, string performer);

    }
}

