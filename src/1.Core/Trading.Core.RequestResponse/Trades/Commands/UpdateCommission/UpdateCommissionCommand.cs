using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Trades.Commands.UpdateCommission;

public sealed class UpdateCommissionCommand : ICommand
{
    public BaseEntityId TradeId { get; init; } = default!;

    public decimal Commission { get; init; }
}