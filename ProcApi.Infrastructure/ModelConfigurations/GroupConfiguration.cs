using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.ChatId);

            builder.HasOne(g => g.Chat)
                .WithOne()
                .HasForeignKey<Group>(g => g.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(g => g.Name)
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(g => g.Description)
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .HasDefaultValue("")
                .IsRequired();

            builder.HasMany(g => g.GroupUsers)
                .WithOne(gu => gu.Group)
                .HasForeignKey(gu => gu.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

