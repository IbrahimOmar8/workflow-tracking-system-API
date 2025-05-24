using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkFlow.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowSteps_Workflows_WorkflowId",
                table: "WorkflowSteps");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkflowId",
                table: "WorkflowSteps",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresValidation",
                table: "WorkflowSteps",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowSteps_Workflows_WorkflowId",
                table: "WorkflowSteps",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowSteps_Workflows_WorkflowId",
                table: "WorkflowSteps");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkflowId",
                table: "WorkflowSteps",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresValidation",
                table: "WorkflowSteps",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowSteps_Workflows_WorkflowId",
                table: "WorkflowSteps",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
