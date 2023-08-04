namespace ProcApi.Data.ProcDatabase.Models
{
    public class DocumentAction
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime ActionPerformed { get; set; }
        public bool IsPerformed { get; set; }
    }
}
