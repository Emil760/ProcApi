﻿using ProcApi.Domain.Enums;

namespace ProcApi.Domain.Entities;

public class Document
{
    public int Id { get; set; }
    public DocumentType TypeId { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; }
    public string? Number { get; set; }
    public DocumentStatus StatusId { get; set; }
    public ICollection<DocumentAction> Actions { get; set; }
}