using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.ResultSets;

namespace ProcApi.Data.ProcDatabase.Configurations;

public class GetCategoriesByLevelConfiguration : IEntityTypeConfiguration<CategoryResultSet>
{
    public void Configure(EntityTypeBuilder<CategoryResultSet> builder)
    {
        builder.HasNoKey();
        builder.ToFunction("get_categories_by_level");
    }
}