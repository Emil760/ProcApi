using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.HasOne(cm => cm.From)
                .WithMany(cm => cm.FromChatMessages)
                .HasForeignKey(cm => cm.FromId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(cm => cm.To)
                .WithMany(cm => cm.ToChatMessages)
                .HasForeignKey(cm => cm.ToId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
