namespace Trading.Core.RequestResponse.Indicators.Commands.RemoveIndicatorParameter;

public sealed class RemoveIndicatorParameterCommandValidator
    : AbstractValidator<RemoveIndicatorParameterCommand>
{
    public RemoveIndicatorParameterCommandValidator()
    {
        RuleFor(x => x.IndicatorId)
            .NotNull();

        RuleFor(x => x.Name)
            .NotEmpty();
    }
}