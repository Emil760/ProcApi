namespace ProcApi.Application.DTOs.User.Requests;

public class RemoveRoleRequest
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}