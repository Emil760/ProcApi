namespace ProcApi.Domain.Entities
{
    public class Dashboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
