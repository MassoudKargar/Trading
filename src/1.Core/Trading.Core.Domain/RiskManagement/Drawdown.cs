namespace Trading.Core.Domain.RiskManagement;

public sealed class Drawdown
{
    public Drawdown(decimal current, decimal maximum)
    {
        Current = current;
        Maximum = maximum;
    }

    public decimal Current { get; private set; }

    public decimal Maximum { get; private set; }

    public void Update(decimal value)
    {
        Current = value;

        if (value > Maximum)
            Maximum = value;
    }
}