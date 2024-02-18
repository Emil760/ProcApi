using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasure1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfMeasureConverter_UnitOfMeasures_SourceUnitOfMeasureId",
                table: "UnitOfMeasureConverter");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfMeasureConverter_UnitOfMeasures_TargetUnitOfMeasureId",
                table: "UnitOfMeasureConverter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasureConverter",
                table: "UnitOfMeasureConverter");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasureConverter",
                newName: "UnitOfMeasureConverters");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOfMeasureConverter_TargetUnitOfMeasureId",
                table: "UnitOfMeasureConverters",
                newName: "IX_UnitOfMeasureConverters_TargetUnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOfMeasureConverter_SourceUnitOfMeasureId",
                table: "UnitOfMeasureConverters",
                newName: "IX_UnitOfMeasureConverters_SourceUnitOfMeasureId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UnitOfMeasures",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanBeDecimal",
                table: "UnitOfMeasureConverters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasureConverters",
                table: "UnitOfMeasureConverters",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3009,
                column: "ApprovalFlowTemplateId",
                value: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfMeasureConverters_UnitOfMeasures_SourceUnitOfMeasureId",
                table: "UnitOfMeasureConverters",
                column: "SourceUnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfMeasureConverters_UnitOfMeasures_TargetUnitOfMeasureId",
                table: "UnitOfMeasureConverters",
                column: "TargetUnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfMeasureConverters_UnitOfMeasures_SourceUnitOfMeasureId",
                table: "UnitOfMeasureConverters");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfMeasureConverters_UnitOfMeasures_TargetUnitOfMeasureId",
                table: "UnitOfMeasureConverters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasureConverters",
                table: "UnitOfMeasureConverters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UnitOfMeasures");

            migrationBuilder.DropColumn(
                name: "CanBeDecimal",
                table: "UnitOfMeasureConverters");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasureConverters",
                newName: "UnitOfMeasureConverter");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOfMeasureConverters_TargetUnitOfMeasureId",
                table: "UnitOfMeasureConverter",
                newName: "IX_UnitOfMeasureConverter_TargetUnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOfMeasureConverters_SourceUnitOfMeasureId",
                table: "UnitOfMeasureConverter",
                newName: "IX_UnitOfMeasureConverter_SourceUnitOfMeasureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasureConverter",
                table: "UnitOfMeasureConverter",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3009,
                column: "ApprovalFlowTemplateId",
                value: 11);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfMeasureConverter_UnitOfMeasures_SourceUnitOfMeasureId",
                table: "UnitOfMeasureConverter",
                column: "SourceUnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfMeasureConverter_UnitOfMeasures_TargetUnitOfMeasureId",
                table: "UnitOfMeasureConverter",
                column: "TargetUnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id");
        }
    }
}
