namespace Trading.Core.RequestResponse.Strategies.Commands.DisableStrategy;

public sealed class DisableStrategyCommandValidator
    : AbstractValidator<DisableStrategyCommand>
{
    public DisableStrategyCommandValidator()
    {
        RuleFor(x => x.StrategyId)
            .NotNull();
    }
}