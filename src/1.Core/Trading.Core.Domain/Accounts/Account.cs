using System.Security.Principal;

using Trading.Core.Domain.Events.Accounts;

namespace Trading.Core.Domain.Accounts;

public sealed class Account : AggregateRoot<BaseEntityId>
{
    private Account(
        string provider,
        string accountNumber,
        string currency,
        Balance balance,
        Margin margin,
        Leverage leverage)
    {
        Id = BaseEntityId.New();
        Provider = provider;
        AccountNumber = accountNumber;
        Currency = currency;

        Balance = balance;
        Margin = margin;
        Leverage = leverage;

        CreatedAt = DateTime.UtcNow;
        AddEvent(new AccountCreatedEvent(Id));
    }

    public string Provider { get; private set; }

    public string AccountNumber { get; private set; }

    public string Currency { get; private set; }

    public Balance Balance { get; private set; }

    public Margin Margin { get; private set; }

    public Leverage Leverage { get; private set; }

    public decimal Equity { get; private set; }

    public decimal MarginLevel { get; private set; }

    public bool IsActive { get; private set; } = true;

    public DateTime CreatedAt { get; }

    public DateTime? UpdatedAt { get; private set; }

    public static Account Create(
        string provider,
        string accountNumber,
        string currency,
        decimal balance,
        int leverage)
    {
        Guard.AgainstNullOrWhiteSpace(provider, nameof(provider));
        Guard.AgainstNullOrWhiteSpace(accountNumber, nameof(accountNumber));
        Guard.AgainstNullOrWhiteSpace(currency, nameof(currency));

        return new Account(
            provider,
            accountNumber,
            currency,
            new Balance(balance),
            new Margin(0, balance),
            new Leverage(leverage));
    }

    public void Deposit(decimal amount)
    {
        Balance = Balance.Deposit(amount);

        UpdatedAt = DateTime.UtcNow;

        AddEvent(new BalanceChangedEvent(
            Id,
            Balance.Amount));
    }

    public void Withdraw(decimal amount)
    {
        Balance = Balance.Withdraw(amount);

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new BalanceChangedEvent(
            Id,
            Balance.Amount));

    }

    public void UpdateMargin(decimal used, decimal free)
    {
        Margin = new Margin(used, free);

        UpdatedAt = DateTime.UtcNow;

        AddEvent(new MarginChangedEvent(
            Id,
            used,
            free));
    }

    public void UpdateEquity(decimal equity)
    {
        Equity = equity;

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new EquityChangedEvent(
            Id,
            equity));
    }

    public void UpdateMarginLevel(decimal level)
    {
        MarginLevel = level;

        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeLeverage(int leverage)
    {
        Leverage = new Leverage(leverage);

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new LeverageChangedEvent(
            Id,
            leverage));
    }

    public void Activate()
    {
        IsActive = true;

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new AccountActivatedEvent(Id));
    }

    public void Deactivate()
    {
        IsActive = false;

        UpdatedAt = DateTime.UtcNow;

        AddEvent(new AccountDeactivatedEvent(Id));
    }

    public bool CanTrade(decimal requiredMargin)
    {
        return IsActive &&
               Margin.Free >= requiredMargin;
    }
}