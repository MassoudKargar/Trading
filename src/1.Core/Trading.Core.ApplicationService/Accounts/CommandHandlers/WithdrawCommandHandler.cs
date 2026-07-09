using Trading.Core.Contracts.Accounts;
using Trading.Core.RequestResponse.Accounts.Commands.Withdraw;

namespace Trading.Core.ApplicationService.Accounts.CommandHandlers;

public sealed class WithdrawCommandHandler(
    BaseServices baseServices,
    IAccountRepository repository)
    : CommandHandler<WithdrawCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        WithdrawCommand command,
        CancellationToken cancellationToken)
    {
        var account = await repository.GetAsync(command.AccountId, cancellationToken);

        account!.Withdraw(command.Amount);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}