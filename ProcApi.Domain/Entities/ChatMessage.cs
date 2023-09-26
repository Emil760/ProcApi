﻿namespace ProcApi.Domain.Entities;

public class ChatMessage
{
    public int Id { get; set; }
    public int ChatId { get; set; }
    public Chat Chat { get; set; }
    public int SenderId { get; set; }
    public User Sender { get; set; }
    public string Message { get; set; }
    public DateTime SendTime { get; set; }
    public ICollection<ReceivedInfo>? ReceivedInfos { get; set; }
}