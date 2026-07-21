using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.RiskManagement;

public sealed class RiskProfileQueryModel
{
    public BaseEntityId Id { get; set; }

    public string Name { get; set; } = default!;

    public decimal RiskPerTrade { get; set; }

    public decimal MaxDailyLoss { get; set; }

    public decimal MaxDrawdown { get; set; }

    public decimal MaxOpenVolume { get; set; }

    public int MaxOpenPositions { get; set; }

    public bool IsEnabled { get; set; }

    public int RulesCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}