namespace WorkFlow.Models
{
    public class Process
    {
        public Guid Id { get; set; } = new Guid();
        public Guid WorkflowId { get; set; }
        public Workflow Workflow { get; set; }
        public string Initiator { get; set; }
        public string Status { get; set; } = "Active"; // Active, Completed
        public ICollection<ProcessStep> Steps { get; set; } = new List<ProcessStep>();
    }
}

