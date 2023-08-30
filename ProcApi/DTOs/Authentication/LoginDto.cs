namespace ProcApi.DTOs.Authentication;

public record LoginDto(
    string Login,
    string Password
);