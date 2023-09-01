using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.User.Requests;

public record AddUserDto(string FirstName,
    string LastName,
    int Age,
    Gender Gender
);