using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentValidationConfiguratonDataSeed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DocumentValidationConfigurations",
                columns: new[] { "Id", "DocumentStatusId", "DocumentTypeId", "IsEnabled", "ValidationDescription", "ValidationName" },
                values: new object[] { 1, 100, 1, true, "", "CheckEmptyItemsAsync" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocumentValidationConfigurations",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
