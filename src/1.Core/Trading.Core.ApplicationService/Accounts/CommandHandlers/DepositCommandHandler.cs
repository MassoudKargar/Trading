using Trading.Core.RequestResponse.Accounts.Commands.Deposit;

namespace Trading.Core.ApplicationService.Accounts.CommandHandlers;

public sealed class DepositCommandHandler(
    BaseServices baseServices,
    IAccountRepository repository)
    : CommandHandler<DepositCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        DepositCommand command,
        CancellationToken cancellationToken)
    {
        var account = await repository.GetAsync(command.AccountId, cancellationToken);

        account!.Deposit(command.Amount);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}