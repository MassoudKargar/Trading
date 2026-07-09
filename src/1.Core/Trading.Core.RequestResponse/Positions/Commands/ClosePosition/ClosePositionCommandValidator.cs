namespace Trading.Core.RequestResponse.Positions.Commands.ClosePosition;

public sealed class ClosePositionCommandValidator
    : AbstractValidator<ClosePositionCommand>
{
    public ClosePositionCommandValidator()
    {
        RuleFor(x => x.PositionId)
            .NotNull();

        RuleFor(x => x.ClosePrice)
            .GreaterThan(0);
    }
}