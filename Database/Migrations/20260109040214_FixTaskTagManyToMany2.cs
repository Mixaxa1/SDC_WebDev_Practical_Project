using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class FixTaskTagManyToMany2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagTodoTask_TodoTasks_TasksId",
                table: "TagTodoTask");

            migrationBuilder.RenameColumn(
                name: "TasksId",
                table: "TagTodoTask",
                newName: "TodoTasksId");

            migrationBuilder.RenameIndex(
                name: "IX_TagTodoTask_TasksId",
                table: "TagTodoTask",
                newName: "IX_TagTodoTask_TodoTasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagTodoTask_TodoTasks_TodoTasksId",
                table: "TagTodoTask",
                column: "TodoTasksId",
                principalTable: "TodoTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagTodoTask_TodoTasks_TodoTasksId",
                table: "TagTodoTask");

            migrationBuilder.RenameColumn(
                name: "TodoTasksId",
                table: "TagTodoTask",
                newName: "TasksId");

            migrationBuilder.RenameIndex(
                name: "IX_TagTodoTask_TodoTasksId",
                table: "TagTodoTask",
                newName: "IX_TagTodoTask_TasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagTodoTask_TodoTasks_TasksId",
                table: "TagTodoTask",
                column: "TasksId",
                principalTable: "TodoTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
