namespace ProcApi.Data.ProcDatabase.Models;

public class RolePermission
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public required Role Role { get; set; }
    public int PermissionId { get; set; }
    public required Permission Permission { get; set; }
}