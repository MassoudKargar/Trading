namespace Trading.Core.RequestResponse.Accounts.Commands.FreezeAccount;

public sealed class FreezeAccountCommand : ICommand
{
    public long AccountId { get; init; }
}