namespace Trading.Core.RequestResponse.Strategies.Commands.StartStrategy;

public sealed class StartStrategyCommandValidator
    : AbstractValidator<StartStrategyCommand>
{
    public StartStrategyCommandValidator()
    {
        RuleFor(x => x.StrategyId)
            .NotNull();
    }
}