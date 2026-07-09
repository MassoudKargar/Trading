namespace Trading.Core.Domain.Positions;

public sealed class PositionPnL
{
    public PositionPnL(
        decimal grossProfit,
        decimal commission,
        decimal swap)
    {
        GrossProfit = grossProfit;
        Commission = commission;
        Swap = swap;
    }

    public decimal GrossProfit { get; }

    public decimal Commission { get; }

    public decimal Swap { get; }

    public decimal NetProfit
        => GrossProfit - Commission - Swap;
}