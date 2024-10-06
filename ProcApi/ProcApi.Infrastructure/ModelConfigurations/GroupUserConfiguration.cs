using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GroupUserConfiguration : IEntityTypeConfiguration<GroupUser>
{
    public void Configure(EntityTypeBuilder<GroupUser> builder)
    {
        builder.HasKey(gu => gu.Id);

        builder.Property(gu => gu.Id)
            .ValueGeneratedNever();

        builder.HasOne(gu => gu.ChatUser)
            .WithOne()
            .HasForeignKey<GroupUser>(gu => gu.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(gu => gu.IsLeaved)
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(false);
    }
}