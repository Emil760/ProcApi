using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class docaction5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentActions_Users_UserId",
                table: "DocumentActions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DocumentActions",
                newName: "AssignerId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentActions_UserId",
                table: "DocumentActions",
                newName: "IX_DocumentActions_AssignerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentActions_Users_AssignerId",
                table: "DocumentActions",
                column: "AssignerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentActions_Users_AssignerId",
                table: "DocumentActions");

            migrationBuilder.RenameColumn(
                name: "AssignerId",
                table: "DocumentActions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentActions_AssignerId",
                table: "DocumentActions",
                newName: "IX_DocumentActions_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentActions_Users_UserId",
                table: "DocumentActions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
