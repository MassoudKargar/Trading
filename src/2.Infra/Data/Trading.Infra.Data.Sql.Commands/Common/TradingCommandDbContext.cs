using Base.Infra.Data.Sql.Commands;

namespace Trading.Infra.Data.Sql.Commands.Common;

public class TradingCommandDbContext(DbContextOptions<TradingCommandDbContext> options) : BaseCommandDbContext(options)
{

    protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}