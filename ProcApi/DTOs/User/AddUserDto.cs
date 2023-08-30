using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.User;

public record AddUserDto(string FirstName,
    string LastName,
    int Age,
    Gender Gender
);