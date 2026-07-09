namespace Trading.Core.RequestResponse.Accounts.Commands.CreateAccount;

public sealed class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(x => x.Provider).NotEmpty();
        RuleFor(x => x.AccountNumber).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty();
        RuleFor(x => x.Balance).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Leverage).GreaterThan(0);
    }
}