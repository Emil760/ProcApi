using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.FunctionConfiguration;

public class GetCategoriesByLevelConfiguration : IEntityTypeConfiguration<CategoryResultSet>
{
    public void Configure(EntityTypeBuilder<CategoryResultSet> builder)
    {
        builder.HasNoKey();
        builder.ToFunction("get_categories_by_level");
    }
}