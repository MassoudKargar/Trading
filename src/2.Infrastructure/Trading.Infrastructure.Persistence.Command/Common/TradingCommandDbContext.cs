using System.Reflection;
using Base.Infra.Data.Sql.Commands;

namespace Trading.Infrastructure.Persistence.Command.Common;

public class TradingCommandDbContext(DbContextOptions<TradingCommandDbContext> options) : BaseCommandDbContext(options)
{

    public DbSet<Trading.Core.Domain.Trades.Trade> Trades => Set<Trading.Core.Domain.Trades.Trade>();
    public DbSet<Trading.Core.Domain.Positions.Position> Positions => Set<Trading.Core.Domain.Positions.Position>();
    public DbSet<Trading.Core.Domain.Orders.Order> Orders => Set<Trading.Core.Domain.Orders.Order>();
    public DbSet<Trading.Core.Domain.Accounts.Account> Accounts => Set<Trading.Core.Domain.Accounts.Account>();
    public DbSet<Trading.Core.Domain.Portfolio.Portfolio> Portfolios => Set<Trading.Core.Domain.Portfolio.Portfolio>();
    public DbSet<Trading.Core.Domain.Strategies.Strategy> Strategies => Set<Trading.Core.Domain.Strategies.Strategy>();
    public DbSet<Trading.Core.Domain.Symbols.Symbol> Symbols => Set<Trading.Core.Domain.Symbols.Symbol>();
    public DbSet<Trading.Core.Domain.Indicators.Indicator> Indicators => Set<Trading.Core.Domain.Indicators.Indicator>();
    public DbSet<Trading.Core.Domain.Market.Candle> Candles => Set<Trading.Core.Domain.Market.Candle>();
    public DbSet<Trading.Core.Domain.OrderBooks.OrderBook> OrderBooks => Set<Trading.Core.Domain.OrderBooks.OrderBook>();
    public DbSet<Trading.Core.Domain.Ticks.Tick> Ticks => Set<Trading.Core.Domain.Ticks.Tick>();
    public DbSet<Trading.Core.Domain.RiskManagement.RiskProfile> RiskProfiles => Set<Trading.Core.Domain.RiskManagement.RiskProfile>();

    protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}