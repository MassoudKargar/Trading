using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Base.Infra.Data.Sql.Commands.Interceptors;
using System.IO;

namespace Trading.Infrastructure.Persistence.Command.Common;

public class TradingCommandDbContextFactory : IDesignTimeDbContextFactory<TradingCommandDbContext>
{
    public TradingCommandDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("CommandDb_ConnectionString") ?? throw new NullReferenceException("CommandDb_ConnectionString is null");
        var builder = new DbContextOptionsBuilder<TradingCommandDbContext>();
        builder.UseSqlServer(connectionString)
            .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor());

        return new TradingCommandDbContext(builder.Options);
    }
}