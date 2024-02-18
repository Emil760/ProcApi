using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasure6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UnitOfMeasureConverters",
                type: "bool",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bool",
                oldDefaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UnitOfMeasureConverters",
                type: "bool",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bool",
                oldDefaultValue: true);
        }
    }
}
