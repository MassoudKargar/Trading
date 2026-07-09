namespace Trading.Core.RequestResponse.Positions.Commands.OpenPosition;

public sealed class OpenPositionCommandValidator
    : AbstractValidator<OpenPositionCommand>
{
    public OpenPositionCommandValidator()
    {
        RuleFor(x => x.Symbol)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Volume)
            .GreaterThan(0);

        RuleFor(x => x.EntryPrice)
            .GreaterThan(0);
    }
}