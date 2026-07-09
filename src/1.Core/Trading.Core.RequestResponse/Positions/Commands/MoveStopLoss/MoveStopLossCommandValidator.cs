namespace Trading.Core.RequestResponse.Positions.Commands.MoveStopLoss;

public sealed class MoveStopLossCommandValidator
    : AbstractValidator<MoveStopLossCommand>
{
    public MoveStopLossCommandValidator()
    {
        RuleFor(x => x.PositionId)
            .NotNull();

        RuleFor(x => x.StopLoss)
            .GreaterThan(0);
    }
}