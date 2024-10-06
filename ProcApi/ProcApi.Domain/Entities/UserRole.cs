using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class UserRole : IEntity<int>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}