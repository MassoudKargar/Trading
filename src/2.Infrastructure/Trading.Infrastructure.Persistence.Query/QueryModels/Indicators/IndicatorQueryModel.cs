using Trading.Core.Resources.Enumerations;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Indicators;

public sealed class IndicatorQueryModel
{
    public BaseEntityId Id { get; set; }

    public string Name { get; set; } = default!;

    public IndicatorType Type { get; set; }

    public bool IsEnabled { get; set; }

    public decimal? LastValue { get; set; }

    public DateTime? LastCalculatedAt { get; set; }

    public int ParametersCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}