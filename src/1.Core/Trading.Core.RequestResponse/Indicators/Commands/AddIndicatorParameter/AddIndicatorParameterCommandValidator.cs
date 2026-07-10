namespace Trading.Core.RequestResponse.Indicators.Commands.AddIndicatorParameter;

public sealed class AddIndicatorParameterCommandValidator
    : AbstractValidator<AddIndicatorParameterCommand>
{
    public AddIndicatorParameterCommandValidator()
    {
        RuleFor(x => x.IndicatorId)
            .NotNull();

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Value);
    }
}