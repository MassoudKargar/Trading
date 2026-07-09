namespace Trading.Core.Contracts.Accounts.QueryResults;

public sealed class GetAccountBalanceQueryResult
{
    public long AccountId { get; set; }
    public decimal Balance { get; set; }
    public decimal Equity { get; set; }
    public decimal Profit { get; set; }
    public decimal Credit { get; set; }
    public string Currency { get; set; } = string.Empty;
}