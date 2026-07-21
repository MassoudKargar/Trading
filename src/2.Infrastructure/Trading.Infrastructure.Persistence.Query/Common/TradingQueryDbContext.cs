using System.Reflection;

using Trading.Infrastructure.Persistence.Query.QueryModels.Accounts;
using Trading.Infrastructure.Persistence.Query.QueryModels.Indicators;
using Trading.Infrastructure.Persistence.Query.QueryModels.Market;
using Trading.Infrastructure.Persistence.Query.QueryModels.OrderBooks;
using Trading.Infrastructure.Persistence.Query.QueryModels.Orders;
using Trading.Infrastructure.Persistence.Query.QueryModels.Portfolio;
using Trading.Infrastructure.Persistence.Query.QueryModels.Positions;
using Trading.Infrastructure.Persistence.Query.QueryModels.RiskManagement;
using Trading.Infrastructure.Persistence.Query.QueryModels.Strategies;
using Trading.Infrastructure.Persistence.Query.QueryModels.Symbols;
using Trading.Infrastructure.Persistence.Query.QueryModels.Trades;

namespace Trading.Infrastructure.Persistence.Query.Common;

public class TradingQueryDbContext(DbContextOptions<TradingQueryDbContext> options)
    : BaseQueryDbContext(options)
{
    public DbSet<AccountQueryModel> Accounts => Set<AccountQueryModel>();

    public DbSet<IndicatorQueryModel> Indicators => Set<IndicatorQueryModel>();

    public DbSet<IndicatorParameterQueryModel> IndicatorParameters => Set<IndicatorParameterQueryModel>();

    public DbSet<TickQueryModel> Ticks => Set<TickQueryModel>();

    public DbSet<CandleQueryModel> Candles => Set<CandleQueryModel>();

    public DbSet<OrderBookQueryModel> OrderBooks => Set<OrderBookQueryModel>();

    public DbSet<OrderBookBidQueryModel> OrderBookBids => Set<OrderBookBidQueryModel>();

    public DbSet<OrderBookAskQueryModel> OrderBookAsks => Set<OrderBookAskQueryModel>();

    public DbSet<OrderQueryModel> Orders => Set<OrderQueryModel>();

    public DbSet<PortfolioQueryModel> Portfolios => Set<PortfolioQueryModel>();

    public DbSet<PositionQueryModel> Positions => Set<PositionQueryModel>();

    public DbSet<RiskProfileQueryModel> RiskProfiles => Set<RiskProfileQueryModel>();

    public DbSet<RiskRuleQueryModel> RiskRules => Set<RiskRuleQueryModel>();

    public DbSet<StrategyQueryModel> Strategies => Set<StrategyQueryModel>();

    public DbSet<SymbolQueryModel> Symbols => Set<SymbolQueryModel>();

    public DbSet<SymbolSessionQueryModel> SymbolSessions => Set<SymbolSessionQueryModel>();

    public DbSet<TradeQueryModel> Trades => Set<TradeQueryModel>();

    protected Assembly ConfigurationsAssembly
        => Assembly.GetExecutingAssembly();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
