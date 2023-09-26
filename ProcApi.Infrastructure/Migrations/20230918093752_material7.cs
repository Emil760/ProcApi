using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Infrastructure.Procedures;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class material7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ProceduresMigrationHelper.CreateGetCategoriesByLevelV1(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ProceduresMigrationHelper.DropGetCategoriesByLevelV1(migrationBuilder);
        }
    }
}
