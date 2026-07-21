using Microsoft.Extensions.DependencyInjection;

using Trading.Core.Contracts.Accounts;
using Trading.Core.Contracts.Indicators;
using Trading.Core.Contracts.Orders;
using Trading.Core.Contracts.Portfolio;
using Trading.Core.Contracts.Positions;
using Trading.Core.Contracts.RiskManagement;
using Trading.Core.Contracts.Strategies;
using Trading.Core.Contracts.Symbols;
using Trading.Core.Contracts.Trades;
using Trading.Infrastructure.Persistence.Query.Repositories;

namespace Trading.Infrastructure.Persistence.Query.DependencyInjection;

public static class QueryPersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddTradingQueryPersistence(this IServiceCollection services)
    {
        services.AddScoped<IAccountQueryRepository, AccountQueryRepository>();
        services.AddScoped<IIndicatorQueryRepository, IndicatorQueryRepository>();
        services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();
        services.AddScoped<IPortfolioQueryRepository, PortfolioQueryRepository>();
        services.AddScoped<IPositionQueryRepository, PositionQueryRepository>();
        services.AddScoped<IRiskProfileQueryRepository, RiskProfileQueryRepository>();
        services.AddScoped<IStrategyQueryRepository, StrategyQueryRepository>();
        services.AddScoped<ISymbolQueryRepository, SymbolQueryRepository>();
        services.AddScoped<ITradeQueryRepository, TradeQueryRepository>();

        return services;
    }
}
