using System;
namespace WorkFlow.Models
{
    public class Workflow
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string Description { get; set; }
        public List<WorkflowStep> Steps { get; set; }
        public string? Priority { get; set; }
        public string? Category { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public string? Status { get; set; }

    }
}

