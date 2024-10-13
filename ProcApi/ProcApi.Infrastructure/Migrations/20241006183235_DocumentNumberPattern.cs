using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DocumentNumberPattern : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentNumberPatternId",
                table: "Documents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocumentNumberPatterns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(300)", nullable: false),
                    DocumentType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2024, 10, 6, 22, 32, 34, 878, DateTimeKind.Local).AddTicks(7454)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentNumberPatterns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentNumberSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentNumberPatternId = table.Column<int>(type: "integer", nullable: false),
                    SectionType = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<short>(type: "smallint", nullable: false),
                    Delimiter = table.Column<string>(type: "varchar(300)", nullable: true),
                    Format = table.Column<string>(type: "varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentNumberSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentNumberSections_DocumentNumberPatterns_DocumentNumbe~",
                        column: x => x.DocumentNumberPatternId,
                        principalTable: "DocumentNumberPatterns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentNumberPatternId",
                table: "Documents",
                column: "DocumentNumberPatternId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentNumberSections_DocumentNumberPatternId",
                table: "DocumentNumberSections",
                column: "DocumentNumberPatternId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentNumberPatterns_DocumentNumberPatternId",
                table: "Documents",
                column: "DocumentNumberPatternId",
                principalTable: "DocumentNumberPatterns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentNumberPatterns_DocumentNumberPatternId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentNumberSections");

            migrationBuilder.DropTable(
                name: "DocumentNumberPatterns");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentNumberPatternId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentNumberPatternId",
                table: "Documents");
        }
    }
}
