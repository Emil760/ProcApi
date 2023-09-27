using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "InvoiceDocuments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InvoiceDocuments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
