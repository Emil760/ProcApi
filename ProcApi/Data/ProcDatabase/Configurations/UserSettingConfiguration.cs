using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations;

public class UserSettingConfiguration : IEntityTypeConfiguration<UserSetting>
{
    public void Configure(EntityTypeBuilder<UserSetting> builder)
    {
        builder.HasKey(us => us.UserId);

        builder.HasOne(us => us.User)
            .WithOne(u => u.UserSetting)
            .HasForeignKey<UserSetting>(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}