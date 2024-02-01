using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Order",
                table: "DocumentActions",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<float>(
                name: "Order",
                table: "ApprovalFlowTemplates",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 1f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 2f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 3f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: 4f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: 1f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: 2f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: 3f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 4f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 1f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 2f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 3f);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Order", "RoleId" },
                values: new object[] { 2.5f, 13 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 20,
                column: "AssignStatusId",
                value: 302);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ActiveStatusId", "AssignStatusId" },
                values: new object[] { 302, 304 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ActiveStatusId", "AssignStatusId" },
                values: new object[] { 301, 303 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ActionTypeId", "ActiveStatusId", "ApprovalFlowTemplateId", "AssignStatusId" },
                values: new object[] { 3, 303, 11, 302 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 24,
                column: "AssignStatusId",
                value: 306);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 26,
                column: "ActiveStatusId",
                value: 302);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 27,
                column: "ActiveStatusId",
                value: 303);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 28,
                column: "AssignStatusId",
                value: 305);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ActiveStatusId", "AssignStatusId" },
                values: new object[] { 302, 305 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ActiveStatusId", "AssignStatusId" },
                values: new object[] { 303, 305 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "DocumentActions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "ApprovalFlowTemplates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ApprovalFlowTemplates",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Order", "RoleId" },
                values: new object[] { 4, 6 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 20,
                column: "AssignStatusId",
                value: 303);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ActiveStatusId", "AssignStatusId" },
                values: new object[] { 303, 305 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ActiveStatusId", "AssignStatusId" },
                values: new object[] { 303, 304 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ActionTypeId", "ActiveStatusId", "ApprovalFlowTemplateId", "AssignStatusId" },
                values: new object[] { 2, 304, 12, 305 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 24,
                column: "AssignStatusId",
                value: 307);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 26,
                column: "ActiveStatusId",
                value: 303);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 27,
                column: "ActiveStatusId",
                value: 304);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 28,
                column: "AssignStatusId",
                value: 306);

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ActiveStatusId", "AssignStatusId" },
                values: new object[] { 303, 306 });

            migrationBuilder.UpdateData(
                table: "ReleaseStrategyTemplates",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ActiveStatusId", "AssignStatusId" },
                values: new object[] { 304, 306 });
        }
    }
}
