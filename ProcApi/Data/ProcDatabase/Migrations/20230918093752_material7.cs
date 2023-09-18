using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Data.ProcDatabase.Procedures;

#nullable disable

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class material7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ProceduresMigrationHelper.CreateGetCategoriesByLevel(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ProceduresMigrationHelper.DropGetCategoriesByLevel(migrationBuilder);
        }
    }
}
