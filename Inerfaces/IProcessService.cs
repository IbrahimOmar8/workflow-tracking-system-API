using System;
using WorkFlow.DTOs;
using WorkFlow.Models;

namespace WorkFlow.Inerfaces
{
	public interface IProcessService
	{
        Task<Process> StartProcessAsync(StartProcessRequestDto request);
        Task<bool> ExecuteStepAsync(ExecuteStepRequestDto request);
        Task<List<Process>> GetProcessesAsync(string? status, Guid? workflowId, string? assignedTo);

    }
}

