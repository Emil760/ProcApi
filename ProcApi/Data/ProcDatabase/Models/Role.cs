namespace ProcApi.Data.ProcDatabase.Models;

public class Role
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Permission> Permissions { get; set; }
}