using ProcApi.Domain.Enums;

namespace ProcApi.Domain.Entities;

public class Chat
{
    public int Id { get; set; }
    public ChatType ChatType { get; set; }
    public ICollection<ChatMessage> ChatMessages { get; set; }
    public ICollection<ChatUser> ChatUsers { get; set; }
}

// public class Group
// {
//     public int ChatId { get; set; }
//     public Chat   Chat { get; set; }
// }
//
// i have this model structure
// when i add Group model into Chat model it created coressponding column in Chat model named GroupId 
// i dont want that to happen but i want to navigate to Group from Chat model
// Group can be null in Chat