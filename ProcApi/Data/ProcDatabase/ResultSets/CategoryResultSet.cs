using System.ComponentModel.DataAnnotations.Schema;

namespace ProcApi.Data.ProcDatabase.ResultSets;

public class CategoryResultSet
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
}