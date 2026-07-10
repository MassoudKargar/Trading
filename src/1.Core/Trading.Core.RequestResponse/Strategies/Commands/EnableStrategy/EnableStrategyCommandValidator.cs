namespace Trading.Core.RequestResponse.Strategies.Commands.EnableStrategy;

public sealed class EnableStrategyCommandValidator
    : AbstractValidator<EnableStrategyCommand>
{
    public EnableStrategyCommandValidator()
    {
        RuleFor(x => x.StrategyId)
            .NotNull();
    }
}