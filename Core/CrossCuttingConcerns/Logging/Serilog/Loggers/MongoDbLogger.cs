using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class MongoDbLogger : LoggerServiceBase
{
    private IConfiguration _configuration;

    public MongoDbLogger()
    {
        
    }

    public MongoDbLogger(IConfiguration configuration)
    {
        _configuration = configuration;
        var logConfig = _configuration.GetSection("SerilogConfigurations:MongoDbConfiguration").Get<MongoDbConfiguration>();
        Logger = new LoggerConfiguration().WriteTo.MongoDB(logConfig.ConnectionString,collectionName:logConfig.Collection).CreateLogger();
    }
}
