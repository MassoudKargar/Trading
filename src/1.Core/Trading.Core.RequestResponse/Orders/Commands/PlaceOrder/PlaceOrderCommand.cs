using Trading.Core.Resources.Enumerations.Orders;

namespace Trading.Core.RequestResponse.Orders.Commands.PlaceOrder;

public sealed class PlaceOrderCommand : ICommand
{
    public string Symbol { get; init; } = default!;

    public OrderType OrderType { get; init; }

    public OrderSide Side { get; init; }

    public decimal Volume { get; init; }

    public decimal Price { get; init; }

    public decimal? StopLoss { get; init; }

    public decimal? TakeProfit { get; init; }
}