using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkflowStepes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WorkflowSteps",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstimatedDuration",
                table: "WorkflowSteps",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsParallel",
                table: "WorkflowSteps",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Workflows",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Workflows",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Workflows",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Workflows",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Workflows",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WorkflowSteps");

            migrationBuilder.DropColumn(
                name: "EstimatedDuration",
                table: "WorkflowSteps");

            migrationBuilder.DropColumn(
                name: "IsParallel",
                table: "WorkflowSteps");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Workflows");
        }
    }
}
