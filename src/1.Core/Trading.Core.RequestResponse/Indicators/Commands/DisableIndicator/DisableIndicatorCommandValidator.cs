namespace Trading.Core.RequestResponse.Indicators.Commands.DisableIndicator;

public sealed class DisableIndicatorCommandValidator
    : AbstractValidator<DisableIndicatorCommand>
{
    public DisableIndicatorCommandValidator()
    {
        RuleFor(x => x.IndicatorId)
            .NotNull();
    }
}