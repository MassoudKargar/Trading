using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Orders.Commands.PlaceOrder;

public sealed class PlaceOrderCommand : ICommand
{
    public BaseEntityId AccountId { get; init; }

    public BaseEntityId PortfolioId { get; init; }

    public BaseEntityId? StrategyId { get; init; }

    public string Broker { get; init; } = default!;

    public string Symbol { get; init; } = default!;

    public OrderType OrderType { get; init; }

    public OrderSide Side { get; init; }

    public decimal Volume { get; init; }

    public decimal Price { get; init; }

    public decimal? StopLoss { get; init; }

    public decimal? TakeProfit { get; init; }

    public decimal? TriggerPrice { get; init; }

    public DateTime? Expiration { get; init; }

    public long MagicNumber { get; init; }
}