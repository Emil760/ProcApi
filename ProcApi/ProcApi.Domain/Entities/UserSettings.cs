using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class UserSetting : IEntity<int>
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Language { get; set; }
}