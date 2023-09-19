using System.ComponentModel.DataAnnotations.Schema;

namespace ProcApi.Data.ProcDatabase.ResultSets;

public class CategoryResultSet
{
    public int Id { get; set; }
    public string Name { get; set; }
}