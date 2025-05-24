using System.Text.Json.Serialization;

namespace WorkFlow.Models
{
    public class WorkflowStep
    {
        public Guid Id { get; set; } = new Guid();
        public string StepName { get; set; }
        public string AssignedTo { get; set; }
        public string ActionType { get; set; }
        public string NextStep { get; set; }
        public bool? RequiresValidation { get; set; } = false;
        public bool? IsParallel { get; set; } = false;
        public string? Description { get; set; }
        public string? EstimatedDuration { get; set; }
        public Guid? WorkflowId { get; set; }
        [JsonIgnore]
        public Workflow? Workflow { get; set; }
    }
}

