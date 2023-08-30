using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Authentication;

public record RegistrationDto(
    string Login,
    string FirstName,
    Gender Gender,
    string Password
);