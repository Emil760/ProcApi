namespace ProcApi.Data.ProcDatabase.Models
{
    public class Document
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public string DocumentNumber { get; set; }
    }
}
