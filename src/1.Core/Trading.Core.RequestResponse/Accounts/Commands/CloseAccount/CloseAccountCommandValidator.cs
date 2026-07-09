namespace Trading.Core.RequestResponse.Accounts.Commands.CloseAccount;

public sealed class CloseAccountCommandValidator : AbstractValidator<CloseAccountCommand>
{
    public CloseAccountCommandValidator()
    {
        RuleFor(x => x.AccountId).GreaterThan(0);
    }
}