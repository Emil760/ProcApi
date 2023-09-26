using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcApi.Infrastructure.Procedures;

public static class ProceduresMigrationHelper
{
    #region GetCategoriesByLevel

    public static void CreateGetCategoriesByLevelV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"CREATE OR REPLACE FUNCTION get_categories_by_level (treeLevel INT)
                               RETURNS TABLE (
                                   ""Id"" int,
                                   ""Name"" varchar
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
                                       SELECT rt.""Id"" AS ""Id"", rt.""Name"" as ""Name""
                                       FROM RecursiveTree rt
                                       WHERE rt.""Level"" = treeLevel;
                               END;
                               $$
                               LANGUAGE PLPGSQL");
    }

    public static void DropGetCategoriesByLevelV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS get_categories_by_level");
    }

    #endregion

    #region GetMaterialWithCategories

    public static void CreateGetMaterialWithCategoriesV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"CREATE OR REPLACE FUNCTION get_material_with_categories(materialId int)
                               RETURNS TABLE (
                               	 ""Id"" int,
                               	 ""Name"" varchar(300),
                                 ""Code"" varchar(300),
                               	 ""CategoryId"" int,
                               	 ""CategoryName"" varchar(300),
                               	 ""Level"" int
                               ) AS
                               $$
                               BEGIN
                               	RETURN QUERY
                               	WITH RECURSIVE RecursiveCTE  AS(
                                   SELECT m.""Id"" AS ""Id"",
                               	m.""Name"" AS ""Name"",
                                m.""Code"" AS ""Code"", 
                               	c.""Id"" AS ""CategoryId"",
                               	c.""Name"" as ""CategoryName"",
                               	c.""ParentCategoryId"" as ""ParentCategoryId"",
                               	0 AS ""Level""
                                   FROM ""Materials"" m
                                   INNER JOIN ""Categories"" c on c.""Id"" = m.""CategoryId""
                                   WHERE m.""Id"" = 1
                               
                                   union all
                               
                                   SELECT rt.""Id"" AS ""Id"",
                               	rt.""Name"" AS ""Name"",
                                rt.""Code"" AS ""Code"",
                               	c.""Id"" as ""CategoryId"",
                               	c.""Name"" as ""CategoryName"",
                               	c.""ParentCategoryId"" as ""ParentCategoryId"",
                               	rt.""Level"" + 1 as ""Level""
                                   FROM RecursiveCTE rt
                                   INNER JOIN ""Categories"" c on c.""Id"" = rt.""ParentCategoryId""
                                   WHERE rt.""ParentCategoryId"" is not null
                               )
                               SELECT rc.""Id"", rc.""Name"", rc.""Code"", rc.""CategoryId"", rc.""CategoryName"", rc.""Level""
                               FROM RecursiveCTE rc;
                               END;
                               $$
                               LANGUAGE 'plpgsql'");
    }

    public static void DropGetMaterialWithCategoriesV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP IF EXISTS FUNCTION get_material_with_categories");
    }

    #endregion
}