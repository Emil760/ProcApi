namespace ProcApi.DTOs.Category.Requests;

public class CreateCategoryDto
{
    public int? ParentCategoryId { get; set; }
    public string Name { get; set; }
}