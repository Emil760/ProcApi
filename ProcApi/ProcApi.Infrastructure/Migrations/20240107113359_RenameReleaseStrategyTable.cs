using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameReleaseStrategyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategies",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.AlterColumn<int>(
                name: "AssignStatusId",
                table: "ReleaseStrategies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActiveStatusId",
                table: "ReleaseStrategies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActionTypeId",
                table: "ReleaseStrategies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "ReleaseStrategies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReleaseStrategyTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActiveStatusId = table.Column<int>(type: "int", nullable: false),
                    AssignStatusId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    IsInitial = table.Column<bool>(type: "boolean", nullable: false),
                    ApprovalFlowTemplateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseStrategyTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseStrategyTemplates_ApprovalFlowTemplates_ApprovalFlow~",
                        column: x => x.ApprovalFlowTemplateId,
                        principalTable: "ApprovalFlowTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ReleaseStrategyTemplates",
                columns: new[] { "Id", "ActionTypeId", "ActiveStatusId", "ApprovalFlowTemplateId", "AssignStatusId", "IsInitial" },
                values: new object[,]
                {
                    { 1, 3, 100, 1, 101, false },
                    { 2, 3, 101, 2, 102, false },
                    { 3, 3, 102, 3, 103, false },
                    { 4, 2, 103, 4, 105, false },
                    { 5, 4, 101, 2, 100, false },
                    { 6, 4, 102, 3, 100, false },
                    { 7, 5, 101, 2, 107, false },
                    { 8, 5, 102, 3, 107, false },
                    { 9, 6, 100, 1, 106, false },
                    { 10, 3, 200, 5, 201, false },
                    { 11, 3, 201, 6, 202, false },
                    { 12, 3, 202, 7, 203, false },
                    { 13, 2, 202, 8, 203, false },
                    { 14, 4, 201, 6, 200, false },
                    { 15, 4, 202, 7, 100, false },
                    { 16, 5, 201, 6, 207, false },
                    { 17, 5, 202, 7, 207, false },
                    { 18, 6, 300, 5, 206, false },
                    { 19, 3, 300, 9, 301, false },
                    { 20, 3, 301, 10, 303, false },
                    { 21, 2, 303, 11, 305, false },
                    { 22, 3, 303, 11, 304, false },
                    { 23, 2, 304, 12, 305, false },
                    { 24, 6, 300, 9, 307, false },
                    { 25, 4, 301, 10, 300, false },
                    { 26, 4, 303, 11, 300, false },
                    { 27, 4, 304, 12, 300, false },
                    { 28, 5, 301, 10, 306, false },
                    { 29, 5, 303, 11, 306, false },
                    { 30, 5, 304, 12, 306, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseStrategies_DocumentId",
                table: "ReleaseStrategies",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseStrategyTemplates_ApprovalFlowTemplateId",
                table: "ReleaseStrategyTemplates",
                column: "ApprovalFlowTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseStrategies_Documents_DocumentId",
                table: "ReleaseStrategies",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseStrategies_Documents_DocumentId",
                table: "ReleaseStrategies");

            migrationBuilder.DropTable(
                name: "ReleaseStrategyTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ReleaseStrategies_DocumentId",
                table: "ReleaseStrategies");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "ReleaseStrategies");

            migrationBuilder.AlterColumn<int>(
                name: "AssignStatusId",
                table: "ReleaseStrategies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ActiveStatusId",
                table: "ReleaseStrategies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ActionTypeId",
                table: "ReleaseStrategies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "ReleaseStrategies",
                columns: new[] { "Id", "ActionTypeId", "ActiveStatusId", "ApprovalFlowTemplateId", "AssignStatusId" },
                values: new object[,]
                {
                    { 1, 3, 100, 1, 101 },
                    { 2, 3, 101, 2, 102 },
                    { 3, 3, 102, 3, 103 },
                    { 4, 2, 103, 4, 105 },
                    { 5, 4, 101, 2, 100 },
                    { 6, 4, 102, 3, 100 },
                    { 7, 5, 101, 2, 107 },
                    { 8, 5, 102, 3, 107 },
                    { 9, 6, 100, 1, 106 },
                    { 10, 3, 200, 5, 201 },
                    { 11, 3, 201, 6, 202 },
                    { 12, 3, 202, 7, 203 },
                    { 13, 2, 202, 8, 203 },
                    { 14, 4, 201, 6, 200 },
                    { 15, 4, 202, 7, 100 },
                    { 16, 5, 201, 6, 207 },
                    { 17, 5, 202, 7, 207 },
                    { 18, 6, 300, 5, 206 },
                    { 19, 3, 300, 9, 301 },
                    { 20, 3, 301, 10, 303 },
                    { 21, 2, 303, 11, 305 },
                    { 22, 3, 303, 11, 304 },
                    { 23, 2, 304, 12, 305 },
                    { 24, 6, 300, 9, 307 },
                    { 25, 4, 301, 10, 300 },
                    { 26, 4, 303, 11, 300 },
                    { 27, 4, 304, 12, 300 },
                    { 28, 5, 301, 10, 306 },
                    { 29, 5, 303, 11, 306 },
                    { 30, 5, 304, 12, 306 }
                });
        }
    }
}
