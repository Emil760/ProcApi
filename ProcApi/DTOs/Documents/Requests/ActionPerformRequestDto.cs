using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Documents.Requests;

public record ActionPerformRequestDto(
    int DocId,
    ActionType ActionType
);