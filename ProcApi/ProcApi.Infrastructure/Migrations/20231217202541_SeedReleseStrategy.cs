using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedReleseStrategy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApprovalFlowTemplates",
                columns: new[] { "Id", "DocumentTypeId", "IsCreator", "IsInitial", "IsMultiple", "Order", "RoleId", "UserId" },
                values: new object[] { 1, 1, true, true, false, 1, 3, null });

            migrationBuilder.InsertData(
                table: "ApprovalFlowTemplates",
                columns: new[] { "Id", "DocumentTypeId", "IsInitial", "IsMultiple", "Order", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 1, true, false, 2, 7, null },
                    { 3, 1, true, false, 3, 8, 12 }
                });

            migrationBuilder.InsertData(
                table: "ApprovalFlowTemplates",
                columns: new[] { "Id", "DocumentTypeId", "IsMultiple", "Order", "RoleId", "UserId" },
                values: new object[] { 4, 1, true, 4, 9, null });

            migrationBuilder.InsertData(
                table: "ApprovalFlowTemplates",
                columns: new[] { "Id", "DocumentTypeId", "IsCreator", "IsInitial", "IsMultiple", "Order", "RoleId", "UserId" },
                values: new object[] { 5, 2, true, true, false, 1, 3, null });

            migrationBuilder.InsertData(
                table: "ApprovalFlowTemplates",
                columns: new[] { "Id", "DocumentTypeId", "IsInitial", "IsMultiple", "Order", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 6, 2, true, false, 2, 7, null },
                    { 7, 2, true, false, 3, 8, 12 }
                });

            migrationBuilder.InsertData(
                table: "ApprovalFlowTemplates",
                columns: new[] { "Id", "DocumentTypeId", "IsMultiple", "Order", "RoleId", "UserId" },
                values: new object[] { 8, 2, true, 4, 9, null });

            migrationBuilder.InsertData(
                table: "ApprovalFlowTemplates",
                columns: new[] { "Id", "DocumentTypeId", "IsCreator", "IsInitial", "IsMultiple", "Order", "RoleId", "UserId" },
                values: new object[] { 9, 3, true, true, false, 1, 9, null });

            migrationBuilder.InsertData(
                table: "ApprovalFlowTemplates",
                columns: new[] { "Id", "DocumentTypeId", "IsInitial", "IsMultiple", "Order", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 10, 3, true, false, 2, 5, 9 },
                    { 11, 3, true, false, 3, 6, 4 }
                });

            migrationBuilder.InsertData(
                table: "ApprovalFlowTemplates",
                columns: new[] { "Id", "DocumentTypeId", "IsMultiple", "Order", "RoleId", "UserId" },
                values: new object[] { 12, 3, false, 4, 6, null });
            
            migrationBuilder.Sql("SELECT setval('\"ApprovalFlowTemplates_Id_seq\"', (SELECT COALESCE(MAX(\"Id\") + 1, 1) FROM \"ApprovalFlowTemplates\"))");

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
            
            migrationBuilder.Sql("SELECT setval('\"ReleaseStrategies_Id_seq\"', (SELECT COALESCE(MAX(\"Id\") + 1, 1) FROM \"ApprovalFlowTemplates\"));");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
