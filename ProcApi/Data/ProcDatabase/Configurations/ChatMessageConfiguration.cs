using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.HasOne(cm => cm.Group)
                .WithMany(g => g.ChatMessages)
                .HasForeignKey(cm => cm.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cm => cm.Sender)
                .WithMany(u => u.ChatMessages)
                .HasForeignKey(cm => cm.SenderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(cm => cm.SendedMessage)
                .HasColumnType("json");

            // builder.Property(cm => cm.Message)
            //     .HasColumnType("nvarchar")
            //     .HasMaxLength(4000);
            //
            // builder.HasOne(cm => cm.From)
            //     .WithMany(cm => cm.FromChatMessages)
            //     .HasForeignKey(cm => cm.FromId)
            //     .OnDelete(DeleteBehavior.NoAction);
            //
            // builder.HasOne(cm => cm.To)
            //     .WithMany(cm => cm.ToChatMessages)
            //     .HasForeignKey(cm => cm.ToId)
            //     .OnDelete(DeleteBehavior.NoAction);
        }
    }
}