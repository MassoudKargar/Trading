using Trading.Core.Domain.Accounts;

namespace Trading.Tests.Domain.Accounts;

public sealed class AccountTests
{
    [Fact]
    public void Create_WithValidData_InitializesActiveAccount()
    {
        var account = Account.Create("Demo", "123", "USD", 1_000, 100);

        Assert.Equal("Demo", account.Provider);
        Assert.Equal("123", account.AccountNumber);
        Assert.Equal("USD", account.Currency);
        Assert.Equal(1_000, account.Balance.Amount);
        Assert.Equal(100, account.Leverage.Value);
        Assert.True(account.IsActive);
        Assert.True(account.CanTrade(1_000));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_WithInvalidProvider_Throws(string provider)
    {
        Assert.Throws<ArgumentException>(() => Account.Create(provider, "123", "USD", 1_000, 100));
    }

    [Fact]
    public void Deposit_AndWithdraw_UpdateBalance()
    {
        var account = Account.Create("Demo", "123", "USD", 1_000, 100);

        account.Deposit(250);
        account.Withdraw(100);

        Assert.Equal(1_150, account.Balance.Amount);
        Assert.NotNull(account.UpdatedAt);
    }

    [Fact]
    public void Deactivate_PreventsTrading()
    {
        var account = Account.Create("Demo", "123", "USD", 1_000, 100);

        account.Deactivate();

        Assert.False(account.IsActive);
        Assert.False(account.CanTrade(1));
    }

    [Fact]
    public void UpdateMargin_UsesFreeMarginForTradeAvailability()
    {
        var account = Account.Create("Demo", "123", "USD", 1_000, 100);

        account.UpdateMargin(900, 100);

        Assert.True(account.CanTrade(100));
        Assert.False(account.CanTrade(101));
    }
}
