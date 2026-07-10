namespace Trading.Core.RequestResponse.Indicators.Commands.CreateIndicator;

public sealed class CreateIndicatorCommandValidator
    : AbstractValidator<CreateIndicatorCommand>
{
    public CreateIndicatorCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}