using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities
{
    public class Dashboard : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
