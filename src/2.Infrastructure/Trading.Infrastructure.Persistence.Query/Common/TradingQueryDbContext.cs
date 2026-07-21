using System.Reflection;

namespace Trading.Infrastructure.Persistence.Query.Common;

public class TradingQueryDbContext(DbContextOptions<TradingQueryDbContext> options)
    : BaseQueryDbContext(options)
{
    protected Assembly ConfigurationsAssembly
        => Assembly.GetExecutingAssembly();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}