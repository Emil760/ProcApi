﻿using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Documents;

public record BaseDocumentDto(
    int DocumentId,
    DocumentType DocumentType,
    DocumentStatus DocumentStatus,
    string DocumentNumber
);