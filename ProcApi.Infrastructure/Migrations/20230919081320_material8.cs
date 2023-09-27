using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Infrastructure.Functions;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class material8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.CreateGetMaterialWithCategoriesV1(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.DropGetMaterialWithCategoriesV1(migrationBuilder);
        }
    }
}
