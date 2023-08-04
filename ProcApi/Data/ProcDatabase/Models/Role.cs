namespace ProcApi.Data.ProcDatabase.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Permission> Permissions { get; set; }
    }
}
