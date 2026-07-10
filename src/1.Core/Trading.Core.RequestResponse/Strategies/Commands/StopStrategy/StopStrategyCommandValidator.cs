namespace Trading.Core.RequestResponse.Strategies.Commands.StopStrategy;

public sealed class StopStrategyCommandValidator
    : AbstractValidator<StopStrategyCommand>
{
    public StopStrategyCommandValidator()
    {
        RuleFor(x => x.StrategyId)
            .NotNull();
    }
}