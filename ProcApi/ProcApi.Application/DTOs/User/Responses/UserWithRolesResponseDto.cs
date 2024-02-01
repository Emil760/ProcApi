namespace ProcApi.Application.DTOs.User.Responses;

public class UserWithRolesResponseDto : UserInfoResponseDto
{
    public string Roles { get; set; }
}