namespace Trading.Core.RequestResponse.Positions.Commands.BreakEven;

public sealed class BreakEvenCommandValidator
    : AbstractValidator<BreakEvenCommand>
{
    public BreakEvenCommandValidator()
    {
        RuleFor(x => x.PositionId)
            .NotNull();

        RuleFor(x => x.StopLoss)
            .GreaterThan(0);
    }
}