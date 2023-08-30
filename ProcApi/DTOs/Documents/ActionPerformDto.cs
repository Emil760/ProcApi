using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Documents;

public record ActionPerformDto(
    int DocId,
    ActionType ActionType
);