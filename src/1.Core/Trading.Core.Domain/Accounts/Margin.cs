using Trading.Core.Resources.Shared.Guards;

namespace Trading.Core.Domain.Accounts;

public sealed class Margin : BaseValueObject<Margin>
{
    public decimal Used { get; }

    public decimal Free { get; }

    public Margin(decimal used, decimal free)
    {
        Guard.AgainstNegative(used, nameof(used));
        Guard.AgainstNegative(free, nameof(free));

        Used = used;
        Free = free;
    }

    public decimal Total => Used + Free;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Used;
        yield return Free;
    }
}