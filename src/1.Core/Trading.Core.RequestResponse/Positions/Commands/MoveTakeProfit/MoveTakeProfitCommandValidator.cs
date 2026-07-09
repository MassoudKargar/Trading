namespace Trading.Core.RequestResponse.Positions.Commands.MoveTakeProfit;

public sealed class MoveTakeProfitCommandValidator
    : AbstractValidator<MoveTakeProfitCommand>
{
    public MoveTakeProfitCommandValidator()
    {
        RuleFor(x => x.PositionId)
            .NotNull();

        RuleFor(x => x.TakeProfit)
            .GreaterThan(0);
    }
}