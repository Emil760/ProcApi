using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class prd2uomc1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PurchaseRequestDocuments",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UnitOfMeasureConverter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceUnitOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    TargetUnitOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasureConverter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureConverter_UnitOfMeasures_SourceUnitOfMeasureId",
                        column: x => x.SourceUnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureConverter_UnitOfMeasures_TargetUnitOfMeasureId",
                        column: x => x.TargetUnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureConverter_SourceUnitOfMeasureId",
                table: "UnitOfMeasureConverter",
                column: "SourceUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureConverter_TargetUnitOfMeasureId",
                table: "UnitOfMeasureConverter",
                column: "TargetUnitOfMeasureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitOfMeasureConverter");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PurchaseRequestDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldDefaultValue: "");
        }
    }
}
