using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Trades.Commands.OpenTrade;

public sealed class OpenTradeCommand : ICommand
{
    public BaseEntityId PositionId { get; init; } = default!;

    public string Symbol { get; init; } = string.Empty;

    public OrderSide Side { get; init; }

    public decimal Volume { get; init; }

    public decimal EntryPrice { get; init; }
}