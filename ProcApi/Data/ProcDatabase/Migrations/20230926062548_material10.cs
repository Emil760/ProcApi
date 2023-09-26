using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class material10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PurchaseRequestDocumentItems");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "PurchaseRequestDocumentItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDocumentItems_MaterialId",
                table: "PurchaseRequestDocumentItems",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDocumentItems_Materials_MaterialId",
                table: "PurchaseRequestDocumentItems",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDocumentItems_Materials_MaterialId",
                table: "PurchaseRequestDocumentItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequestDocumentItems_MaterialId",
                table: "PurchaseRequestDocumentItems");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "PurchaseRequestDocumentItems");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PurchaseRequestDocumentItems",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
