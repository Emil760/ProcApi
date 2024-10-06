using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class Role : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Permission> Permissions { get; set; }
    public ICollection<User> Users { get; set; }
}