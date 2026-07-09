using Trading.Core.Contracts.Accounts;

namespace Trading.Core.ApplicationService.Accounts.CommandHandlers;

public sealed class CreateAccountCommandHandler(
    BaseServices baseServices,
    IAccountRepository repository)
    : CommandHandler<CreateAccountCommand, BaseEntityId>(baseServices)
{
    public override async Task<CommandResult<BaseEntityId>> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
    {

        var account = Account.Create(
            command.Provider,
            command.AccountNumber,
            command.Currency,
            command.Balance,
            command.Leverage);

        await repository.InsertAsync(account, cancellationToken);

        await repository.CommitAsync(cancellationToken);

        return Ok(account.Id);
    }
}