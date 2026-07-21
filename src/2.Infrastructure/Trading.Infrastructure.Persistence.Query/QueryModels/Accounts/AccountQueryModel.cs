using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Accounts;

public sealed class AccountQueryModel
{
    public BaseEntityId Id { get; set; }

    public string Provider { get; set; } = default!;

    public string AccountNumber { get; set; } = default!;

    public string Currency { get; set; } = default!;

    public decimal Balance { get; set; }

    public decimal Equity { get; set; }

    public decimal MarginUsed { get; set; }

    public decimal MarginFree { get; set; }

    public decimal MarginLevel { get; set; }

    public int Leverage { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}