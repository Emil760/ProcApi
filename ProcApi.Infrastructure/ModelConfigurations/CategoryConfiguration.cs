using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

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