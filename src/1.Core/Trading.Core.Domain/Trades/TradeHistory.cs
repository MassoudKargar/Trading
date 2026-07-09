namespace Trading.Core.Domain.Trades;

public sealed class TradeHistory
{
    private readonly List<Trade> _trades = [];

    public IReadOnlyCollection<Trade> Trades
        => _trades.AsReadOnly();

    public void Add(Trade trade)
    {
        _trades.Add(trade);
    }

    public decimal TotalProfit
        => _trades.Sum(x => x.NetProfit);

    public int Wins
        => _trades.Count(x => x.NetProfit > 0);

    public int Losses
        => _trades.Count(x => x.NetProfit < 0);

    public int TotalTrades
        => _trades.Count;

    public decimal WinRate
    {
        get
        {
            if (_trades.Count == 0)
                return 0;

            return (decimal)Wins / _trades.Count * 100m;
        }
    }

    public Trade? LastTrade
        => _trades.LastOrDefault();
}