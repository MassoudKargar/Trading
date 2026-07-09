using Base.Core.RequestResponse.Commands;

namespace Trading.Core.RequestResponse.Accounts.Commands.Deposit;

public sealed class DepositCommand : ICommand
{
    public long AccountId { get; init; }
    public decimal Amount { get; init; }
}