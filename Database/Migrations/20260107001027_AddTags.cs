using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tags");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
