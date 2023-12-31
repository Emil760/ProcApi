﻿using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.Documents.Base;

public class BaseDocumentDto
{
    public int DocumentId { get; set; }
    public DocumentType DocumentType { get; set; }
    public DocumentStatus DocumentStatus { get; set; }
    public string DocumentNumber { get; set; }
    public DateTime CreatedOn { get; set; }
}