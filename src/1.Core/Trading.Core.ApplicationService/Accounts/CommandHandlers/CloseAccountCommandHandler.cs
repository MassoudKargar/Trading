using Trading.Core.Contracts.Accounts;
using Trading.Core.RequestResponse.Accounts.Commands.CloseAccount;

namespace Trading.Core.ApplicationService.Accounts.CommandHandlers;

public sealed class CloseAccountCommandHandler(
    BaseServices baseServices,
    IAccountRepository repository)
    : CommandHandler<CloseAccountCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        CloseAccountCommand command,
        CancellationToken cancellationToken)
    {
        var account = await repository.GetAsync(command.AccountId, cancellationToken);

        account!.Deactivate();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}