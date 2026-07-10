using Trading.Core.Contracts.Indicators.Queries;
using Trading.Core.Resources.Enumerations;

namespace Trading.Core.ApplicationService.Indicators.QueryHandlers;

public sealed class IndicatorQueryFilter()
    : PagedSortableQueryFilter<IndicatorQueryFilter.SortIndicatorPropertyNames>(new SortIndicatorPropertyNames()),
        IQuery<PagedCollectionQueryResult<GetAllIndicatorQueryResult>>,
        IQuery<GetIndicatorByIdQueryResult>,
        IQuery<GetIndicatorValueQueryResult>
{
    public sealed class SortIndicatorPropertyNames : ISortablePropertyCollection
    {
        public const string IndicatorId = nameof(IndicatorId);
        public const string Name = nameof(Name);
        public const string Type = nameof(Type);
        public const string CreatedAt = nameof(CreatedAt);

        public string GetDefault() => CreatedAt;
    }

    public BaseEntityId? IndicatorId { get; set; }

    public string? Name { get; set; }

    public IndicatorType? Type { get; set; }

    public bool? IsEnabled { get; set; }
}