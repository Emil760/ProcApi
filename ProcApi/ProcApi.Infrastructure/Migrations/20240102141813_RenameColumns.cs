using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Documents",
                newName: "DocumentTypeId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Documents",
                newName: "DocumentStatusId");

            migrationBuilder.RenameColumn(
                name: "ChatType",
                table: "Chats",
                newName: "ChatTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "PurchaseRequestItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentTypeId",
                table: "Documents",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "DocumentStatusId",
                table: "Documents",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "ChatTypeId",
                table: "Chats",
                newName: "ChatType");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "PurchaseRequestItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
