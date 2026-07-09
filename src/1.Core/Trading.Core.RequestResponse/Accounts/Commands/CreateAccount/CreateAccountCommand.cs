using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Accounts.Commands.CreateAccount;

public sealed class CreateAccountCommand : ICommand<BaseEntityId>
{
    public string Provider { get; init; } = default!;

    public string AccountNumber { get; init; } = default!;

    public string Currency { get; init; } = default!;

    public decimal Balance { get; init; }

    public int Leverage { get; init; }
}