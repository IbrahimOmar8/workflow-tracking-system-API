namespace WorkFlow.Models
{
    public class ValidationLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProcessId { get; set; }
        public string StepName { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}

