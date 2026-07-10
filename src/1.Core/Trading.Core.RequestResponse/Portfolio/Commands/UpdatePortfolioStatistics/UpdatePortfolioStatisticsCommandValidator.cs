namespace Trading.Core.RequestResponse.Portfolio.Commands.UpdatePortfolioStatistics;

public sealed class UpdatePortfolioStatisticsCommandValidator
    : AbstractValidator<UpdatePortfolioStatisticsCommand>
{
    public UpdatePortfolioStatisticsCommandValidator()
    {
        RuleFor(x => x.PortfolioId)
            .NotNull();

        RuleFor(x => x.Balance)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Equity)
            .GreaterThanOrEqualTo(0);
    }
}