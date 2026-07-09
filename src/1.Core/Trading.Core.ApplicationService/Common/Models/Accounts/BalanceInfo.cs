namespace Trading.Core.ApplicationService.Common.Models.Accounts;

public sealed record BalanceInfo(
    string Asset,
    decimal Free,
    decimal Locked);