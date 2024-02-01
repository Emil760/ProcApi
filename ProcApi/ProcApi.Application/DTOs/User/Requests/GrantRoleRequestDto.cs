namespace ProcApi.Application.DTOs.User.Requests;

public class GrantRoleRequestDto
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}