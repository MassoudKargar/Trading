namespace Trading.Core.Domain.Strategies;

public sealed class StrategySignal
{
    public StrategySignal(
        string symbol,
        SignalType signal,
        decimal price)
    {
        Symbol = symbol;
        Signal = signal;
        Price = price;

        CreatedAt = DateTime.UtcNow;
    }

    public string Symbol { get; }

    public SignalType Signal { get; }

    public decimal Price { get; }

    public decimal? StopLoss { get; private set; }

    public decimal? TakeProfit { get; private set; }

    public DateTime CreatedAt { get; }

    public void SetStopLoss(decimal stopLoss)
    {
        StopLoss = stopLoss;
    }

    public void SetTakeProfit(decimal takeProfit)
    {
        TakeProfit = takeProfit;
    }
}