namespace ProcApi.Application.DTOs.DropDown.Requests;

public class CreateDropDownItemRequest
{
    public int DropDownSourceId { get; set; }
    public string Value { get; set; }
}