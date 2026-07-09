namespace Trading.Core.Domain.Indicators;

public sealed class IndicatorParameter
{
    public IndicatorParameter(
        string name,
        decimal value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; }

    public decimal Value { get; private set; }

    public void Update(decimal value)
    {
        Value = value;
    }
}