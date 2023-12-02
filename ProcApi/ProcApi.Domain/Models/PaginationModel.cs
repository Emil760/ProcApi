namespace ProcApi.Domain.Models;

public class PaginationModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string Search { get; set; } = "";
    public string Sort { get; set; } = "";
}