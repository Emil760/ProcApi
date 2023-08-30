using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class prd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RequestedForDepartmentId",
                table: "PurchaseRequestDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RequestedForDepartmentId",
                table: "PurchaseRequestDocuments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
