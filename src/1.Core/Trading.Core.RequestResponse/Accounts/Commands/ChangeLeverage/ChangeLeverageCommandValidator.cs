namespace Trading.Core.RequestResponse.Accounts.Commands.ChangeLeverage;

public sealed class ChangeLeverageCommandValidator : AbstractValidator<ChangeLeverageCommand>
{
    public ChangeLeverageCommandValidator()
    {
        RuleFor(x => x.AccountId).GreaterThan(0);
        RuleFor(x => x.Leverage).GreaterThan(0);
    }
}