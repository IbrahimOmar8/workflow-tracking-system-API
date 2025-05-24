namespace WorkFlow.Models
{
    public class ProcessStep
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProcessId { get; set; }
        public Process Process { get; set; }

        public string StepName { get; set; }
        public string PerformedBy { get; set; }
        public string Action { get; set; }
        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;
        public bool IsValid { get; set; }
    }
}

