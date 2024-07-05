using ProcApi.Application.DTOs.User.Base;

namespace ProcApi.Application.DTOs.User.Responses;

public class UserResponse : UserDto
{
    public int Id { get; set; }
}