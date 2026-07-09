namespace Trading.Core.RequestResponse.Accounts.Commands.Withdraw;

public sealed class WithdrawCommandValidator : AbstractValidator<WithdrawCommand>
{
    public WithdrawCommandValidator()
    {
        RuleFor(x => x.AccountId).GreaterThan(0);
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}