namespace Trading.Core.RequestResponse.Accounts.Commands.CloseAccount;

public sealed class CloseAccountCommand : ICommand
{
    public long AccountId { get; init; }
}