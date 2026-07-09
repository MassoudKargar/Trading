using Trading.Core.Contracts.Accounts;
using Trading.Core.RequestResponse.Accounts.Commands.UnfreezeAccount;

namespace Trading.Core.ApplicationService.Accounts.CommandHandlers;

public sealed class UnfreezeAccountCommandHandler(
    BaseServices baseServices,
    IAccountRepository repository)
    : CommandHandler<UnfreezeAccountCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UnfreezeAccountCommand command,
        CancellationToken cancellationToken)
    {
        var account = await repository.GetAsync(command.AccountId, cancellationToken);

        account!.Activate();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}