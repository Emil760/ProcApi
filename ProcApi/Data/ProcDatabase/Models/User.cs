using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public ICollection<ChatMessage> FromChatMessages { get; set; }
        public ICollection<ChatMessage> ToChatMessages { get; set; }
    }
}
