namespace Trading.Core.RequestResponse.Orders.Commands.SetTakeProfit;

public sealed class SetTakeProfitCommandValidator
    : AbstractValidator<SetTakeProfitCommand>
{
    public SetTakeProfitCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .GreaterThan(0);

        RuleFor(x => x.TakeProfit)
            .GreaterThan(0);
    }
}