namespace Trading.Core.RequestResponse.Indicators.Commands.EnableIndicator;

public sealed class EnableIndicatorCommandValidator
    : AbstractValidator<EnableIndicatorCommand>
{
    public EnableIndicatorCommandValidator()
    {
        RuleFor(x => x.IndicatorId)
            .NotNull();
    }
}