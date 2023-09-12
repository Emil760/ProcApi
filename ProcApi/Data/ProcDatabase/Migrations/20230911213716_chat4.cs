using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class chat4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Groups_GroupChatId",
                table: "ChatUsers");

            migrationBuilder.DropIndex(
                name: "IX_ChatUsers_GroupChatId",
                table: "ChatUsers");

            migrationBuilder.DropColumn(
                name: "ChatRole",
                table: "ChatUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ChatUsers");

            migrationBuilder.DropColumn(
                name: "GroupChatId",
                table: "ChatUsers");

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    ChatUserId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    ChatRole = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.ChatUserId);
                    table.ForeignKey(
                        name: "FK_GroupUsers_ChatUsers_ChatUserId",
                        column: x => x.ChatUserId,
                        principalTable: "ChatUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.AddColumn<int>(
                name: "ChatRole",
                table: "ChatUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ChatUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GroupChatId",
                table: "ChatUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_GroupChatId",
                table: "ChatUsers",
                column: "GroupChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Groups_GroupChatId",
                table: "ChatUsers",
                column: "GroupChatId",
                principalTable: "Groups",
                principalColumn: "ChatId");
        }
    }
}
