namespace Trading.Core.RequestResponse.Orders.Commands.PlaceOrder;

public sealed class PlaceOrderCommandValidator
    : AbstractValidator<PlaceOrderCommand>
{
    public PlaceOrderCommandValidator()
    {
        RuleFor(x => x.Symbol)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Volume)
            .GreaterThan(0);

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.StopLoss)
            .GreaterThan(0)
            .When(x => x.StopLoss.HasValue);

        RuleFor(x => x.TakeProfit)
            .GreaterThan(0)
            .When(x => x.TakeProfit.HasValue);
    }
}