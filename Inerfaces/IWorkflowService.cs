using System;
using WorkFlow.Models;

namespace WorkFlow.Inerfaces
{
	public interface IWorkflowService
	{
        Task<Workflow> CreateWorkflowAsync(Workflow workflow);

        Task<Workflow> UpdatedWorkflowAsync(Guid id ,Workflow workflow);

        Task<Workflow> GetWorkflowByIdAsync(Guid id);

    }
}

