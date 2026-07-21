using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.RiskManagement;

public sealed class RiskRuleQueryModel
{
    public long Id { get; set; }

    public BaseEntityId RiskProfileId { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public bool IsEnabled { get; set; }
}
