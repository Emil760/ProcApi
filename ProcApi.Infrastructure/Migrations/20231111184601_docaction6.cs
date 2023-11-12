using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class docaction6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerformerId",
                table: "DocumentActions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentActions_PerformerId",
                table: "DocumentActions",
                column: "PerformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentActions_Users_PerformerId",
                table: "DocumentActions",
                column: "PerformerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentActions_Users_PerformerId",
                table: "DocumentActions");

            migrationBuilder.DropIndex(
                name: "IX_DocumentActions_PerformerId",
                table: "DocumentActions");

            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "DocumentActions");
        }
    }
}
