namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;

public class MssqlConfiguration
{
    public string ConnectionString { get; set; }
    public string TableName { get; set; }
    public bool AutoCreateSqlTable { get; set; }
}
