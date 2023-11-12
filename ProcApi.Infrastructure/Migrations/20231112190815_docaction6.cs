using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                nullable: true);

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 19, "CanReturnInvoice" },
                    { 20, "CanRejectInvoice" },
                    { 21, "CanReturnPurchaseRequest" },
                    { 22, "CanRejectPurchaseRequest" }
                });

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

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DropColumn(
                name: "PerformerId",
                table: "DocumentActions");
        }
    }
}
