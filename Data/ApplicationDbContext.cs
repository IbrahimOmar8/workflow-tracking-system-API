using System;
using Microsoft.EntityFrameworkCore;
using WorkFlow.Models;

namespace WorkFlow.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<WorkflowStep> WorkflowSteps { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessStep> ProcessSteps { get; set; }
        public DbSet<ValidationLog> ValidationLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workflow>()
                .HasMany(w => w.Steps)
                .WithOne(s => s.Workflow)
                .HasForeignKey(s => s.WorkflowId);
        }
    }
}