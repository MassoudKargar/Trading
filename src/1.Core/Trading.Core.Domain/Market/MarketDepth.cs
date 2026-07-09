namespace Trading.Core.Domain.Market;

public sealed class MarketDepth
{
    public MarketDepth(
        decimal price,
        decimal volume)
    {
        Price = price;
        Volume = volume;
    }

    public decimal Price { get; }

    public decimal Volume { get; }
}