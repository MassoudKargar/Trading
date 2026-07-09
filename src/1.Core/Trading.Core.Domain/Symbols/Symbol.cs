namespace Trading.Core.Domain.Symbols;

public sealed class Symbol : AggregateRoot<BaseEntityId>
{
    private Symbol(
        string name,
        string baseCurrency,
        string quoteCurrency,
        int digits,
        decimal tickSize,
        decimal lotSize)
    {
        Id = BaseEntityId.New();
        Name = name;
        BaseCurrency = baseCurrency;
        QuoteCurrency = quoteCurrency;
        Digits = digits;
        TickSize = tickSize;
        LotSize = lotSize;

        TradingHours = new TradingHours();

        IsTradable = true;

        CreatedAt = DateTime.UtcNow;
    }

    public string Name { get; private set; }

    public string BaseCurrency { get; private set; }

    public string QuoteCurrency { get; private set; }

    public int Digits { get; private set; }

    public decimal TickSize { get; private set; }

    public decimal LotSize { get; private set; }

    public decimal Spread { get; private set; }

    public bool IsTradable { get; private set; }

    public TradingHours TradingHours { get; }

    public DateTime CreatedAt { get; }

    public DateTime? UpdatedAt { get; private set; }

    public static Symbol Create(
        string name,
        string baseCurrency,
        string quoteCurrency,
        int digits,
        decimal tickSize,
        decimal lotSize)
    {
        Guard.AgainstNullOrWhiteSpace(name, nameof(name));
        Guard.AgainstNullOrWhiteSpace(baseCurrency, nameof(baseCurrency));
        Guard.AgainstNullOrWhiteSpace(quoteCurrency, nameof(quoteCurrency));

        return new Symbol(
            name,
            baseCurrency,
            quoteCurrency,
            digits,
            tickSize,
            lotSize);
    }

    public void UpdateSpread(decimal spread)
    {
        Guard.AgainstNegative(spread, nameof(spread));

        Spread = spread;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateLotSize(decimal lotSize)
    {
        Guard.AgainstNegative(lotSize, nameof(lotSize));

        LotSize = lotSize;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateTickSize(decimal tickSize)
    {
        Guard.AgainstNegative(tickSize, nameof(tickSize));

        TickSize = tickSize;
        UpdatedAt = DateTime.UtcNow;
    }

    public void EnableTrading()
    {
        IsTradable = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void DisableTrading()
    {
        IsTradable = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public bool IsMarketOpen(DateTime utcNow)
    {
        return IsTradable &&
               TradingHours.IsMarketOpen(utcNow);
    }

    public decimal NormalizePrice(decimal price)
    {
        return Math.Round(price, Digits);
    }

    public decimal NormalizeVolume(decimal volume)
    {
        if (LotSize <= 0)
            return volume;

        return Math.Round(volume / LotSize) * LotSize;
    }
}