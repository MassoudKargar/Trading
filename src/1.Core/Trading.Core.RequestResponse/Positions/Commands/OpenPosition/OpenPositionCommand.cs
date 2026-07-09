using Trading.Core.Resources.Enumerations.Orders;

namespace Trading.Core.RequestResponse.Positions.Commands.OpenPosition;

public sealed class OpenPositionCommand : ICommand
{
    public string Symbol { get; init; } = default!;

    public OrderSide Side { get; init; }

    public decimal Volume { get; init; }

    public decimal EntryPrice { get; init; }
}