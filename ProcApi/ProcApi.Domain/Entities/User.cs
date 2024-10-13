using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class User : IEntity<int>
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }

    public UserPassword UserPassword { get; set; }
    public UserSetting UserSetting { get; set; }
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public int? DashboardId { get; set; }
    public ICollection<Role> Roles { get; set; }

    public ICollection<Delegation> FromDelegations { get; set; }
    public ICollection<Delegation> ToDelegations { get; set; }

    public ICollection<Document> Documents { get; set; }

    public ICollection<ChatUser> ChatUsers { get; set; }
    public ICollection<ChatMessage> ChatMessages { get; set; }
}