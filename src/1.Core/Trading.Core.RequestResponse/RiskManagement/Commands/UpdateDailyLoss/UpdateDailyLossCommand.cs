using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateDailyLoss;

public sealed class UpdateDailyLossCommand : ICommand
{
    public BaseEntityId RiskProfileId { get; init; } = default!;

    public decimal MaxDailyLoss { get; init; }
}