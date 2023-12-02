using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.FunctionConfiguration;

public class GetMaterialWithCategoriesConfiguration : IEntityTypeConfiguration<MaterialResultSet>
{
    public void Configure(EntityTypeBuilder<MaterialResultSet> builder)
    {
        builder.HasNoKey();
        builder.ToFunction("get_material_with_categories");
    }
}