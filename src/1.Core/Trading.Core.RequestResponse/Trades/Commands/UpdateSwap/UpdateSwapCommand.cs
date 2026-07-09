using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Trades.Commands.UpdateSwap;

public sealed class UpdateSwapCommand : ICommand
{
    public BaseEntityId TradeId { get; init; } = default!;

    public decimal Swap { get; init; }
}