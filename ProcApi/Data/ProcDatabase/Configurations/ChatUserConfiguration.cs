using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations;

public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
{
    public void Configure(EntityTypeBuilder<ChatUser> builder)
    {
        builder.HasOne(cu => cu.Chat)
            .WithMany(c => c.ChatUsers)
            .HasForeignKey(cu => cu.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cu => cu.User)
            .WithMany(u => u.ChatUsers)
            .HasForeignKey(cu => cu.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}