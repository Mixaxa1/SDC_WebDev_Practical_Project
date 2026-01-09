using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskTagManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TodoTasks_TodoTaskId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TodoTaskId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TodoTaskId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "TagTodoTask",
                columns: table => new
                {
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTodoTask", x => new { x.TagsId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_TagTodoTask_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTodoTask_TodoTasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "TodoTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagTodoTask_TasksId",
                table: "TagTodoTask",
                column: "TasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTodoTask");

            migrationBuilder.AddColumn<Guid>(
                name: "TodoTaskId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TodoTaskId",
                table: "Tags",
                column: "TodoTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TodoTasks_TodoTaskId",
                table: "Tags",
                column: "TodoTaskId",
                principalTable: "TodoTasks",
                principalColumn: "Id");
        }
    }
}
