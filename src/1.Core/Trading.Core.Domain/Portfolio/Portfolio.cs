using Trading.Core.Domain.Events.Portfolio;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Portfolio;

public sealed class Portfolio : AggregateRoot<BaseEntityId>
{
    private readonly List<BaseEntityId> _positions = [];

    private readonly List<BaseEntityId> _trades = [];

    public Portfolio(
        BaseEntityId accountId)
    {
        Id = new BaseEntityId();
        AccountId = accountId;

        Statistics = new PortfolioStatistics(
            0,
            0,
            0,
            0);

        CreatedAt = DateTime.UtcNow;
        AddEvent(new PortfolioCreatedEvent(
            Id,
            AccountId));
    }

    public BaseEntityId AccountId { get; private set; }

    public PortfolioStatistics Statistics { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime? UpdatedAt { get; private set; }

    public void UpdateStatistics(
        decimal balance,
        decimal equity,
        decimal floatingProfit,
        decimal realizedProfit)
    {
        Statistics = new PortfolioStatistics(
            balance,
            equity,
            floatingProfit,
            realizedProfit);

        UpdatedAt = DateTime.UtcNow;

        AddEvent(new PortfolioUpdatedEvent(Id));

        AddEvent(new PortfolioBalanceChangedEvent(
            Id,
            Statistics.Balance));

        AddEvent(new PortfolioEquityChangedEvent(
            Id,
            Statistics.Equity));

        AddEvent(new PortfolioFloatingProfitChangedEvent(
            Id,
            Statistics.FloatingProfit));

        AddEvent(new PortfolioRealizedProfitChangedEvent(
            Id,
            Statistics.RealizedProfit));

        AddEvent(new PortfolioProfitChangedEvent(
            Id,
            Statistics.TotalProfit));

        AddEvent(new PortfolioDrawdownChangedEvent(
            Id,
            Statistics.Drawdown));
    }
}