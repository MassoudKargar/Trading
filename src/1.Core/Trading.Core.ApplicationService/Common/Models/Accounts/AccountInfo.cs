namespace Trading.Core.ApplicationService.Common.Models.Accounts;
public sealed record AccountInfo(
    decimal Balance,
    decimal Equity,
    decimal UsedMargin,
    decimal FreeMargin,
    decimal MarginLevel,
    int Leverage,
    string Currency,
    IReadOnlyCollection<BalanceInfo> Balances);