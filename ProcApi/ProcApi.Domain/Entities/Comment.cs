using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities
{
    public class Comment : IEntity<int>
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
