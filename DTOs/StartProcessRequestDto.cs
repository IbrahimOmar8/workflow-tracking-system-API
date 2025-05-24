using System;
namespace WorkFlow.DTOs
{
	public class StartProcessRequestDto
	{
        public Guid WorkflowId { get; set; }
        public string Initiator { get; set; }
    }
}

