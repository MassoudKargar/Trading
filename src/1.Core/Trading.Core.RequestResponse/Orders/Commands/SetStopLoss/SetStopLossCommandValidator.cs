namespace Trading.Core.RequestResponse.Orders.Commands.SetStopLoss;

public sealed class SetStopLossCommandValidator
    : AbstractValidator<SetStopLossCommand>
{
    public SetStopLossCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0);

        RuleFor(x => x.StopLoss)
            .GreaterThan(0);
    }
}