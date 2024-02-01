namespace ProcApi.Application.DTOs.User.Requests;

public class RemoveRoleRequestDto
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}