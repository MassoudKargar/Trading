namespace Trading.Core.Contracts.Portfolio.Queries;

public sealed class GetAllPortfolioQueryResult
{
    public BaseEntityId PortfolioId { get; set; }

    public BaseEntityId AccountId { get; set; }

    public decimal Balance { get; set; }

    public decimal Equity { get; set; }

    public decimal FloatingProfit { get; set; }

    public decimal RealizedProfit { get; set; }

    public decimal TotalProfit { get; set; }

    public decimal Drawdown { get; set; }

    public int OpenPositions { get; set; }

    public int TotalTrades { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}