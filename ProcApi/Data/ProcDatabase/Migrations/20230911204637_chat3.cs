using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class chat3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Groups_GroupId",
                table: "ChatUsers");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "ChatUsers",
                newName: "GroupChatId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUsers_GroupId",
                table: "ChatUsers",
                newName: "IX_ChatUsers_GroupChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Groups_GroupChatId",
                table: "ChatUsers",
                column: "GroupChatId",
                principalTable: "Groups",
                principalColumn: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Groups_GroupChatId",
                table: "ChatUsers");

            migrationBuilder.RenameColumn(
                name: "GroupChatId",
                table: "ChatUsers",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUsers_GroupChatId",
                table: "ChatUsers",
                newName: "IX_ChatUsers_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Groups_GroupId",
                table: "ChatUsers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
