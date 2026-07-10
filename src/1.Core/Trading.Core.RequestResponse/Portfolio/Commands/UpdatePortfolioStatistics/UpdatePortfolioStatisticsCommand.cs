using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Portfolio.Commands.UpdatePortfolioStatistics;

public sealed class UpdatePortfolioStatisticsCommand : ICommand
{
    public BaseEntityId PortfolioId { get; init; } = default!;

    public decimal Balance { get; init; }

    public decimal Equity { get; init; }

    public decimal FloatingProfit { get; init; }

    public decimal RealizedProfit { get; init; }
}