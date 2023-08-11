namespace ProcApi.Data.ProcDatabase.Models;

public class Permission
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Role> Roles { get; set; }
}