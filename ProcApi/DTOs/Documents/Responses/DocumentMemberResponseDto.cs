using ProcApi.Enums;

namespace ProcApi.DTOs.Documents.Responses;

public record DocumentMemberResponseDto(
    string MemberName,
    Roles RoleId,
    DateTime ActionPerformed,
    bool IsPerformed
);