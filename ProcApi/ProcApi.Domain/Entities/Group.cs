using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class Group : IEntity<int>
{
    public int Id { get; set; }
    public Chat Chat { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<GroupUser> GroupUsers { get; set; }
}