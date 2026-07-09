namespace Trading.Core.Domain.Indicators;

public sealed class IndicatorValue
{
    public IndicatorValue(decimal value)
    {
        Value = value;

        CalculatedAt = DateTime.UtcNow;
    }

    public decimal Value { get; }

    public DateTime CalculatedAt { get; }
}