using Trading.Core.Contracts.Accounts;
using Trading.Core.RequestResponse.Accounts.Commands.FreezeAccount;

namespace Trading.Core.ApplicationService.Accounts.CommandHandlers;

public sealed class FreezeAccountCommandHandler(
    BaseServices baseServices,
    IAccountRepository repository)
    : CommandHandler<FreezeAccountCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        FreezeAccountCommand command,
        CancellationToken cancellationToken)
    {
        var account = await repository.GetAsync(command.AccountId, cancellationToken);

        account!.Deactivate();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}