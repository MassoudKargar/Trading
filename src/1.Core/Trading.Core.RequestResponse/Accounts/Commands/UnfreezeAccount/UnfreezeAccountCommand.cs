using Base.Core.RequestResponse.Commands;

namespace Trading.Core.RequestResponse.Accounts.Commands.UnfreezeAccount;

public sealed class UnfreezeAccountCommand : ICommand
{
    public long AccountId { get; init; }
}