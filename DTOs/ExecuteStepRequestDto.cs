using System;
namespace WorkFlow.DTOs
{
	public class ExecuteStepRequestDto
	{

        public Guid ProcessId { get; set; }
        public string StepName { get; set; }
        public string PerformedBy { get; set; }
        public string Action { get; set; }

    }
}

