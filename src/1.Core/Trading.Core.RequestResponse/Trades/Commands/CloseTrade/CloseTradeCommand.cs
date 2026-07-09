using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Trades.Commands.CloseTrade;

public sealed class CloseTradeCommand : ICommand
{
    public BaseEntityId TradeId { get; init; } = default!;

    public decimal ExitPrice { get; init; }

    public decimal GrossProfit { get; init; }

    public decimal Commission { get; init; }

    public decimal Swap { get; init; }
}