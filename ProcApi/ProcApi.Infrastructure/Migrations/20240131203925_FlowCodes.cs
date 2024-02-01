using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FlowCodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReleaseStrategies");

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DropColumn(
                name: "IsInitial",
                table: "ReleaseStrategyTemplates");

            migrationBuilder.AddColumn<string>(
                name: "FlowCodes",
                table: "ReleaseStrategyTemplates",
                type: "varchar",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlowCodes",
                table: "Documents",
                type: "varchar",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlowCode",
                table: "ApprovalFlowTemplates",
                type: "varchar",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "FlowCode",
                value: "STANDART");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "FlowCode",
                value: "STANDART");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "FlowCode",
                value: "STANDART");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 4,
                column: "FlowCode",
                value: "BUYER");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 5,
                column: "FlowCode",
                value: "STANDART");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 6,
                column: "FlowCode",
                value: "STANDART");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 7,
                column: "FlowCode",
                value: "STANDART");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 8,
                column: "FlowCode",
                value: "BUYER");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 9,
                column: "FlowCode",
                value: "STANDART");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 10,
                column: "FlowCode",
                value: "STANDART");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 11,
                column: "FlowCode",
                value: "STANDART");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 12,
                column: "FlowCode",
                value: "REVIEWER");

            migrationBuilder.InsertData(
                table: "ReleaseStrategyTemplates",
                columns: new[] { "Id", "ActionTypeId", "ActiveStatusId", "ApprovalFlowTemplateId", "AssignStatusId", "FlowCodes" },
                values: new object[,]
                {
                    { 1000, 3, 100, 1, 101, "STANDART" },
                    { 1001, 3, 101, 2, 102, "STANDART" },
                    { 1002, 3, 102, 3, 103, "STANDART" },
                    { 1003, 4, 101, 2, 100, "STANDART" },
                    { 1004, 4, 102, 3, 100, "STANDART" },
                    { 1005, 5, 101, 2, 107, "STANDART" },
                    { 1006, 5, 102, 3, 107, "STANDART" },
                    { 1007, 6, 100, 1, 106, "STANDART" },
                    { 1008, 3, 100, 1, 101, "STANDART_BUYER" },
                    { 1009, 3, 101, 2, 102, "STANDART_BUYER" },
                    { 1010, 3, 102, 3, 103, "STANDART_BUYER" },
                    { 1011, 2, 103, 4, 105, "STANDART_BUYER" },
                    { 1012, 4, 101, 2, 100, "STANDART_BUYER" },
                    { 1013, 4, 102, 3, 100, "STANDART_BUYER" },
                    { 1014, 5, 101, 2, 107, "STANDART_BUYER" },
                    { 1015, 5, 102, 3, 107, "STANDART_BUYER" },
                    { 1016, 6, 100, 1, 106, "STANDART" },
                    { 2000, 3, 200, 5, 201, "STANDART" },
                    { 2001, 3, 201, 6, 202, "STANDART" },
                    { 2002, 3, 202, 7, 203, "STANDART" },
                    { 2003, 4, 201, 6, 200, "STANDART" },
                    { 2004, 4, 202, 7, 100, "STANDART" },
                    { 2005, 5, 201, 6, 207, "STANDART" },
                    { 2006, 5, 202, 7, 207, "STANDART" },
                    { 2007, 6, 300, 5, 206, "STANDART" },
                    { 2008, 3, 200, 5, 201, "STANDART_BUYER" },
                    { 2009, 3, 201, 6, 202, "STANDART_BUYER" },
                    { 2010, 3, 202, 7, 203, "STANDART_BUYER" },
                    { 2011, 2, 202, 8, 203, "STANDART_BUYER" },
                    { 2012, 4, 201, 6, 200, "STANDART_BUYER" },
                    { 2013, 4, 202, 7, 100, "STANDART_BUYER" },
                    { 2014, 5, 201, 6, 207, "STANDART_BUYER" },
                    { 2015, 5, 202, 7, 207, "STANDART_BUYER" },
                    { 2016, 6, 300, 5, 206, "STANDART_BUYER" },
                    { 3000, 3, 300, 9, 301, "STANDART" },
                    { 3001, 3, 301, 10, 302, "STANDART" },
                    { 3002, 2, 302, 11, 304, "STANDART" },
                    { 3003, 6, 300, 9, 306, "STANDART" },
                    { 3004, 4, 301, 10, 300, "STANDART" },
                    { 3005, 4, 302, 11, 300, "STANDART" },
                    { 3006, 5, 301, 10, 305, "STANDART" },
                    { 3007, 5, 302, 11, 305, "STANDART" },
                    { 3008, 3, 300, 9, 301, "STANDART_REVIEWER" },
                    { 3009, 3, 301, 11, 303, "STANDART_REVIEWER" },
                    { 3010, 2, 302, 11, 304, "STANDART_REVIEWER" },
                    { 3011, 6, 300, 9, 306, "STANDART_REVIEWER" },
                    { 3012, 4, 301, 10, 300, "STANDART_REVIEWER" },
                    { 3013, 4, 302, 11, 300, "STANDART_REVIEWER" },
                    { 3014, 4, 303, 12, 300, "STANDART_REVIEWER" },
                    { 3015, 5, 301, 10, 305, "STANDART_REVIEWER" },
                    { 3016, 5, 302, 11, 305, "STANDART_REVIEWER" },
                    { 3017, 5, 303, 12, 305, "STANDART_REVIEWER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2000);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2001);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2003);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2004);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2005);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2006);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2007);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2008);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2009);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2010);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2011);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2012);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2013);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2014);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2015);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 2016);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3000);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3001);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3002);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3003);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3004);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3005);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3006);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3007);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3008);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3009);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3010);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3011);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3012);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3013);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3014);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3015);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3016);

            migrationBuilder.DeleteData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 3017);

            migrationBuilder.DropColumn(
                name: "FlowCodes",
                table: "ReleaseStrategyTemplates");

            migrationBuilder.DropColumn(
                name: "FlowCodes",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FlowCode",
                table: "ApprovalFlowTemplates");

            migrationBuilder.AddColumn<bool>(
                name: "IsInitial",
                table: "ReleaseStrategyTemplates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ReleaseStrategies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApprovalFlowTemplateId = table.Column<int>(type: "integer", nullable: false),
                    DocumentId = table.Column<int>(type: "integer", nullable: false),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatusId = table.Column<int>(type: "integer", nullable: false),
                    AssignStatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseStrategies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseStrategies_ApprovalFlowTemplates_ApprovalFlowTemplat~",
                        column: x => x.ApprovalFlowTemplateId,
                        principalTable: "ApprovalFlowTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReleaseStrategies_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
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
                    { 20, 3, 301, 10, 302, false },
                    { 21, 2, 302, 11, 304, false },
                    { 22, 3, 301, 11, 303, false },
                    { 23, 3, 303, 11, 302, false },
                    { 24, 6, 300, 9, 306, false },
                    { 25, 4, 301, 10, 300, false },
                    { 26, 4, 302, 11, 300, false },
                    { 27, 4, 303, 12, 300, false },
                    { 28, 5, 301, 10, 305, false },
                    { 29, 5, 302, 11, 305, false },
                    { 30, 5, 303, 12, 305, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseStrategies_ApprovalFlowTemplateId",
                table: "ReleaseStrategies",
                column: "ApprovalFlowTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseStrategies_DocumentId",
                table: "ReleaseStrategies",
                column: "DocumentId");
        }
    }
}
