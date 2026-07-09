using Base.Core.RequestResponse.Commands;

namespace Trading.Core.RequestResponse.Accounts.Commands.Withdraw;

public sealed class WithdrawCommand : ICommand
{
    public long AccountId { get; init; }
    public decimal Amount { get; init; }
}