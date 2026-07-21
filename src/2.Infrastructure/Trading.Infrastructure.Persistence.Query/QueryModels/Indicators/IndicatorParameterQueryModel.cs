using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Indicators;

public sealed class IndicatorParameterQueryModel
{
    public BaseEntityId IndicatorId { get; set; }

    public string Name { get; set; } = default!;

    public decimal Value { get; set; }
}