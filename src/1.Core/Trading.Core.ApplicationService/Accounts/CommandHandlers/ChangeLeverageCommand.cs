using Trading.Core.RequestResponse.Accounts.Commands.ChangeLeverage;

namespace Trading.Core.ApplicationService.Accounts.CommandHandlers;

public sealed class ChangeLeverageCommandHandler(
    BaseServices baseServices,
    IAccountRepository repository)
    : CommandHandler<ChangeLeverageCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        ChangeLeverageCommand command,
        CancellationToken cancellationToken)
    {
        var account = await repository.GetAsync(command.AccountId, cancellationToken);

        account!.ChangeLeverage(command.Leverage);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}