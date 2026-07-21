using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Trading.Infrastructure.Persistence.Query.Common;

public class TradingQueryDbContextFactory
    : IDesignTimeDbContextFactory<TradingQueryDbContext>
{
    public TradingQueryDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("QueryDb_ConnectionString")
                               ?? throw new NullReferenceException("QueryDb_ConnectionString is null");

        var builder = new DbContextOptionsBuilder<TradingQueryDbContext>();

        builder.UseSqlServer(connectionString);

        return new TradingQueryDbContext(builder.Options);
    }
}