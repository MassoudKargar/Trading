namespace Trading.Core.Domain.Accounts;

public sealed class Leverage : BaseValueObject<Leverage>
{
    public int Value { get; }

    public Leverage(int value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return $"1:{Value}";
    }
}
