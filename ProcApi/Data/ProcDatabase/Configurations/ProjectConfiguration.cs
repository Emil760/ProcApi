using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(p => p.Name)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();
    }
}