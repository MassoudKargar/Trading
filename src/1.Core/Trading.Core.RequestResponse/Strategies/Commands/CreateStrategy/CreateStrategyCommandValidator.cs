namespace Trading.Core.RequestResponse.Strategies.Commands.CreateStrategy;

public sealed class CreateStrategyCommandValidator
    : AbstractValidator<CreateStrategyCommand>
{
    public CreateStrategyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.TimeFrame)
            .NotEmpty();

        RuleFor(x => x.RiskPercent)
            .GreaterThan(0);

        RuleFor(x => x.RiskReward)
            .GreaterThan(0);

        RuleFor(x => x.MaxOpenPositions)
            .GreaterThan(0);
    }
}