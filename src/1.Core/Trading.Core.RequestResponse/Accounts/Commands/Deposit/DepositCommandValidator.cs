using FluentValidation;

namespace Trading.Core.RequestResponse.Accounts.Commands.Deposit;

public sealed class DepositCommandValidator : AbstractValidator<DepositCommand>
{
    public DepositCommandValidator()
    {
        RuleFor(x => x.AccountId).GreaterThan(0);
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}