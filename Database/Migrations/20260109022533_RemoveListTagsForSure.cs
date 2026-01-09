using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveListTagsForSure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TodoLists_TodoListId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TodoListId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TodoListId",
                table: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TodoListId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TodoListId",
                table: "Tags",
                column: "TodoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TodoLists_TodoListId",
                table: "Tags",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id");
        }
    }
}
