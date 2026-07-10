using Trading.Core.Resources.Enumerations;

namespace Trading.Core.Contracts.Indicators.Queries;

public sealed class GetAllIndicatorQueryResult
{
    public BaseEntityId IndicatorId { get; set; }

    public string Name { get; set; } = string.Empty;

    public IndicatorType Type { get; set; }

    public bool IsEnabled { get; set; }

    public decimal? LastValue { get; set; }

    public DateTime? CalculatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}