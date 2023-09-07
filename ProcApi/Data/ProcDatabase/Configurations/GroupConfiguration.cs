using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.Property(g => g.Name)
            .HasColumnType("nvarchar")
            .HasMaxLength(300)
            .IsRequired();

        builder.HasMany(g => g.Users)
            .WithMany()
            .UsingEntity<GroupUser>();
    }
}