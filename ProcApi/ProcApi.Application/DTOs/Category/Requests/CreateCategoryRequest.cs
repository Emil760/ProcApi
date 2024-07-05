namespace ProcApi.Application.DTOs.Category.Requests;

public class CreateCategoryRequest
{
    public int? ParentCategoryId { get; set; }
    public string Name { get; set; }
}