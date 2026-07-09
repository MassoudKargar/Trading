using FluentValidation;

namespace Trading.Core.RequestResponse.Accounts.Commands.UnfreezeAccount;

public sealed class UnfreezeAccountCommandValidator : AbstractValidator<UnfreezeAccountCommand>
{
    public UnfreezeAccountCommandValidator()
    {
        RuleFor(x => x.AccountId).GreaterThan(0);
    }
}