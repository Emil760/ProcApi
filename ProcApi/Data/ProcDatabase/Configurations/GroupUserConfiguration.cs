using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations;

public class GroupUserConfiguration : IEntityTypeConfiguration<GroupUser>
{
    public void Configure(EntityTypeBuilder<GroupUser> builder)
    {
        builder.HasKey(gu => gu.ChatUserId);

        builder.HasOne(gu => gu.ChatUser)
            .WithOne()
            .HasForeignKey<GroupUser>(gu => gu.ChatUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(gu => gu.IsLeaved)
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(false);
    }
}