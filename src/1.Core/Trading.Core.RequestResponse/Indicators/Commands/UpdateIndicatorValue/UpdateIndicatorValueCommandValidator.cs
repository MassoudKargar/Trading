namespace Trading.Core.RequestResponse.Indicators.Commands.UpdateIndicatorValue;

public sealed class UpdateIndicatorValueCommandValidator
    : AbstractValidator<UpdateIndicatorValueCommand>
{
    public UpdateIndicatorValueCommandValidator()
    {
        RuleFor(x => x.IndicatorId)
            .NotNull();

        RuleFor(x => x.Value);
    }
}