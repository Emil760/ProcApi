namespace ProcApi.Configurations.Options;

public class ProcDatabaseOptions
{
    public string ConnectionString { get; set; }
    public int MaxRetryCount { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedErrors { get; set; }
    public bool EnableSensetiveDataLogging { get; set; }
}