using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class docaction3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentTypeId",
                table: "Documents",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "DocumentStatusId",
                table: "Documents",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "Documents",
                newName: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Documents",
                newName: "DocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Documents",
                newName: "DocumentStatusId");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Documents",
                newName: "DocumentNumber");
        }
    }
}
