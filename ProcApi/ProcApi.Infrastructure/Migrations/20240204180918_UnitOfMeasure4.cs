using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasure4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBeDecimal",
                table: "UnitOfMeasureConverters");

            migrationBuilder.AddColumn<bool>(
                name: "CanBeDecimal",
                table: "UnitOfMeasures",
                type: "bool",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBeDecimal",
                table: "UnitOfMeasures");

            migrationBuilder.AddColumn<bool>(
                name: "CanBeDecimal",
                table: "UnitOfMeasureConverters",
                type: "bool",
                nullable: false,
                defaultValue: false);
        }
    }
}
