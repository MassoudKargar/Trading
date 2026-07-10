using Trading.Core.Resources.Enumerations;

namespace Trading.Core.Contracts.Indicators.Queries;

public sealed class GetIndicatorByIdQueryResult
{
    public BaseEntityId IndicatorId { get; set; }

    public string Name { get; set; } = string.Empty;

    public IndicatorType Type { get; set; }

    public bool IsEnabled { get; set; }

    public IReadOnlyCollection<IndicatorParameterQueryResult> Parameters { get; set; }
        = [];

    public decimal? LastValue { get; set; }

    public DateTime? CalculatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

public sealed class IndicatorParameterQueryResult
{
    public string Name { get; set; } = string.Empty;

    public decimal Value { get; set; }
}