using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Infrastructure.Migrations.Helpers;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class docaction7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.CreateGetUserRolesWithDelegatedRolesV1(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.DropGetUserRolesWithDelegatedRolesV1(migrationBuilder);
        }
    }
}
