using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Data.ProcDatabase.ResultSets;

namespace ProcApi.Data.ProcDatabase.Configurations;

public class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.Property(x => x.Name)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasColumnType("varchar")
            .HasMaxLength(1000)
            .HasDefaultValue("");

        builder.Property(x => x.Code)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.HasOne(m => m.Category)
            .WithMany(c => c.Materials)
            .HasForeignKey(m => m.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class GetMaterialWithCategoriesConfiguration : IEntityTypeConfiguration<MaterialResultSet>
{
    public void Configure(EntityTypeBuilder<MaterialResultSet> builder)
    {
        builder.HasNoKey();
        builder.ToFunction("get_material_with_categories");
    }
}