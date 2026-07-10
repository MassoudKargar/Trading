namespace Trading.Core.Contracts.Indicators.Queries;

public sealed class GetIndicatorValueQueryResult
{
    public BaseEntityId IndicatorId { get; set; }

    public decimal? Value { get; set; }

    public DateTime? CalculatedAt { get; set; }
}