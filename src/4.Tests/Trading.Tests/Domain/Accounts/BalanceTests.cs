using Trading.Core.Domain.Accounts;

namespace Trading.Tests.Domain.Accounts;

public sealed class BalanceTests
{
    [Fact]
    public void Deposit_ReturnsNewBalanceWithAddedAmount()
    {
        var balance = new Balance(100);

        var result = balance.Deposit(25);

        Assert.Equal(125, result.Amount);
        Assert.Equal(100, balance.Amount);
    }

    [Fact]
    public void Withdraw_WhenAmountExceedsBalance_Throws()
    {
        var balance = new Balance(100);

        Assert.Throws<InvalidOperationException>(() => balance.Withdraw(101));
    }
}
