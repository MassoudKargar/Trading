namespace Trading.Core.RequestResponse.Positions.Commands.PartialClosePosition;

public sealed class PartialClosePositionCommandValidator
    : AbstractValidator<PartialClosePositionCommand>
{
    public PartialClosePositionCommandValidator()
    {
        RuleFor(x => x.PositionId)
            .NotNull();

        RuleFor(x => x.Volume)
            .GreaterThan(0);
    }
}