using Base.Core.RequestResponse.Commands;

namespace Trading.Core.RequestResponse.Accounts.Commands.CloseAccount;

public sealed class CloseAccountCommand : ICommand
{
    public long AccountId { get; init; }
}