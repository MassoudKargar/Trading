using Trading.Core.Resources.Shared.Guards;

namespace Trading.Core.Domain.Accounts;

public sealed class Balance : BaseValueObject<Balance>
{
    public decimal Amount { get; }

    public Balance(decimal amount)
    {
        Guard.AgainstNegative(amount, nameof(amount));

        Amount = amount;
    }

    public Balance Deposit(decimal amount)
    {
        Guard.AgainstNegative(amount, nameof(amount));

        return new Balance(Amount + amount);
    }

    public Balance Withdraw(decimal amount)
    {
        Guard.AgainstNegative(amount, nameof(amount));

        if (amount > Amount)
            throw new InvalidOperationException("Insufficient balance.");

        return new Balance(Amount - amount);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
    }
}