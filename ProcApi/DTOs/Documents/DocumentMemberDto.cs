using ProcApi.Enums;

namespace ProcApi.DTOs.Documents;

public record DocumentMemberDto(
    string MemberName,
    Roles RoleId,
    DateTime ActionPerformed,
    bool IsPerformed
);