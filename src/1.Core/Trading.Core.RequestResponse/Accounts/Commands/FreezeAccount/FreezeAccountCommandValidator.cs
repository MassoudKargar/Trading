using FluentValidation;

namespace Trading.Core.RequestResponse.Accounts.Commands.FreezeAccount;

public sealed class FreezeAccountCommandValidator : AbstractValidator<FreezeAccountCommand>
{
    public FreezeAccountCommandValidator()
    {
        RuleFor(x => x.AccountId).GreaterThan(0);
    }
}