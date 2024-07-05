namespace ProcApi.Application.DTOs.User.Requests;

public class GrantRoleRequest
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}