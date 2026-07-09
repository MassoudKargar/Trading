namespace Trading.Core.Contracts.Accounts.QueryResults;

public sealed class GetAccountByIdQueryResult
{
    public long AccountId { get; set; }
    public string Provider { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public decimal Equity { get; set; }
    public decimal FreeMargin { get; set; }
    public decimal UsedMargin { get; set; }
    public decimal MarginLevel { get; set; }
    public int Leverage { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastActivity { get; set; }
}