namespace Trading.Core.Contracts.Accounts.QueryResults;

public sealed class GetAccountMarginQueryResult
{
    public long AccountId { get; set; }
    public decimal UsedMargin { get; set; }
    public decimal FreeMargin { get; set; }
    public decimal MarginLevel { get; set; }
    public decimal StopOutLevel { get; set; }
}