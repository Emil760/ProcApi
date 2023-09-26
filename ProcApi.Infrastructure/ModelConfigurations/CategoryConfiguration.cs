using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.ModelConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();
        }
    }

    public class GetCategoriesByLevelConfiguration : IEntityTypeConfiguration<CategoryResultSet>
    {
        public void Configure(EntityTypeBuilder<CategoryResultSet> builder)
        {
            builder.HasNoKey();
            builder.ToFunction("get_categories_by_level");
        }
    }
}

