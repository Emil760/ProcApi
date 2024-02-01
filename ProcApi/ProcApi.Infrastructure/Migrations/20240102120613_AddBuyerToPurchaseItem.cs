using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBuyerToPurchaseItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "PurchaseRequestItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 27, "CanAssignBuyer" });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItems_BuyerId",
                table: "PurchaseRequestItems",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestItems_Users_BuyerId",
                table: "PurchaseRequestItems",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestItems_Users_BuyerId",
                table: "PurchaseRequestItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequestItems_BuyerId",
                table: "PurchaseRequestItems");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "PurchaseRequestItems");
        }
    }
}
