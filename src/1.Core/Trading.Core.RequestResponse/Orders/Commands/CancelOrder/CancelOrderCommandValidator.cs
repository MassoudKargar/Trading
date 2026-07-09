namespace Trading.Core.RequestResponse.Orders.Commands.CancelOrder;

public sealed class CancelOrderCommandValidator
    : AbstractValidator<CancelOrderCommand>
{
    public CancelOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0);
    }
}