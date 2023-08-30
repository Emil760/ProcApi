using Microsoft.AspNetCore.Components.Web;
using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class ControlSet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    //public string ActionCode { get; set; }
    public ActionType? ActionTypeId { get; set; }
    public DocumentType DocumentTypeId { get; set; }
    public DocumentStatus DocumentStatusId { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public bool IsVisible { get; set; }
    public bool IsEditable { get; set; }
    public bool IsMandatory { get; set; }
    //public bool IsDef { get; set; }
}