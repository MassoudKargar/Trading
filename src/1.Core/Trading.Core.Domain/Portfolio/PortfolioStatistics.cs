namespace Trading.Core.Domain.Portfolio;

public sealed class PortfolioStatistics
{
    public PortfolioStatistics(
        decimal balance,
        decimal equity,
        decimal floatingProfit,
        decimal realizedProfit)
    {
        Balance = balance;
        Equity = equity;
        FloatingProfit = floatingProfit;
        RealizedProfit = realizedProfit;
    }

    public decimal Balance { get; }

    public decimal Equity { get; }

    public decimal FloatingProfit { get; }

    public decimal RealizedProfit { get; }

    public decimal TotalProfit
        => FloatingProfit + RealizedProfit;

    public decimal Drawdown { get; private set; }

    public decimal MaxDrawdown { get; private set; }

    public void UpdateDrawdown(decimal drawdown)
    {
        Drawdown = drawdown;

        if (drawdown > MaxDrawdown)
            MaxDrawdown = drawdown;
    }
}