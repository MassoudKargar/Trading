namespace Trading.Core.RequestResponse.Positions.Commands.ActivateTrailingStop;

public sealed class ActivateTrailingStopCommandValidator
    : AbstractValidator<ActivateTrailingStopCommand>
{
    public ActivateTrailingStopCommandValidator()
    {
        RuleFor(x => x.PositionId)
            .NotNull();

        RuleFor(x => x.StopLoss)
            .GreaterThan(0);
    }
}