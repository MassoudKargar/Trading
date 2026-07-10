namespace Trading.Core.RequestResponse.Portfolio.Commands.CreatePortfolio;

public sealed class CreatePortfolioCommandValidator
    : AbstractValidator<CreatePortfolioCommand>
{
    public CreatePortfolioCommandValidator()
    {
        RuleFor(x => x.AccountId)
            .NotNull();
    }
}