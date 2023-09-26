using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Data.ProcDatabase.Procedures;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class material8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ProceduresMigrationHelper.CreateGetMaterialWithCategoriesV1(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ProceduresMigrationHelper.DropGetMaterialWithCategoriesV1(migrationBuilder);
        }
    }
}
