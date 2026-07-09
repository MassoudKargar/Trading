namespace Trading.Core.Contracts.Accounts.QueryResults;

public sealed class GetAccountLeverageQueryResult
{
    public long AccountId { get; set; }
    public int Leverage { get; set; }
    public decimal MaxLot { get; set; }
    public decimal MinLot { get; set; }
    public decimal LotStep { get; set; }
}