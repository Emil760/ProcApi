using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.HasOne(cm => cm.Chat)
            .WithMany(g => g.ChatMessages)
            .HasForeignKey(cm => cm.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cm => cm.Sender)
            .WithMany(u => u.ChatMessages)
            .HasForeignKey(cm => cm.SenderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(cm => cm.Message)
            .HasColumnType("varchar")
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(cm => cm.SendTime)
            .HasColumnType("timestamp without time zone")
            .IsRequired()
            .HasDefaultValueSql("CURRENT_DATE");

        builder.Property(cm => cm.ReceivedInfos)
            .HasColumnType("jsonb")
            .IsRequired(false);
    }
}