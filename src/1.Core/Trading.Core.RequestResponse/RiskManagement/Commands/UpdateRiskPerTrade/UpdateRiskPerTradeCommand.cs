using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateRiskPerTrade;

public sealed class UpdateRiskPerTradeCommand : ICommand
{
    public BaseEntityId RiskProfileId { get; init; } = default!;

    public decimal RiskPerTrade { get; init; }
}