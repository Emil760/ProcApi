using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcApi.Data.ProcDatabase.Procedures;

public static class ProceduresMigrationHelper
{
    public static void CreateGetCategoriesByLevel(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"CREATE OR REPLACE FUNCTION get_categories_by_level (treeLevel INT)
                               RETURNS TABLE (
                                   Id int,
                                   Name varchar
                               ) AS
                               $$
                               BEGIN
                                       RETURN QUERY
                                       WITH RECURSIVE RecursiveTree AS (
                                       SELECT c.""Id"", c.""Name"", 0 AS ""Level""
                                       FROM ""Categories"" c
                                       WHERE ""ParentCategoryId"" IS NULL
                               
                                       UNION ALL
                                       SELECT c.""Id"", c.""Name"", r.""Level"" + 1 as ""Level""
                                       FROM ""Categories"" c
                                       INNER JOIN RecursiveTree r ON r.""Id"" = c.""ParentCategoryId""
                                       )
                                       SELECT rt.""Id"", rt.""Name""
                                       FROM RecursiveTree rt
                                       WHERE rt.""Level"" = treeLevel;
                               END;
                               $$
                               LANGUAGE PLPGSQL");
    }

    public static void DropGetCategoriesByLevel(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS get_categories_by_level");
    }
}