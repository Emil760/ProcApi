using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class UserPassword : IEntity<int>
{
    public int Id { get; set; }
    public User User { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public DateTime LastModified { get; set; }
}