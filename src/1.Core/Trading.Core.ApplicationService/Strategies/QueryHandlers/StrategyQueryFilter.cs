using Trading.Core.Contracts.Strategies.Queries;
using Trading.Core.Resources.Enumerations.Strategies;

namespace Trading.Core.ApplicationService.Strategies.QueryHandlers;

public sealed class StrategyQueryFilter()
    : PagedSortableQueryFilter<StrategyQueryFilter.SortStrategyPropertyNames>(new SortStrategyPropertyNames()),
        IQuery<PagedCollectionQueryResult<GetAllStrategyQueryResult>>,
        IQuery<GetStrategyByIdQueryResult>,
        IQuery<GetStrategyStatusQueryResult>
{
    public sealed class SortStrategyPropertyNames : ISortablePropertyCollection
    {
        public const string StrategyId = nameof(StrategyId);
        public const string Name = nameof(Name);
        public const string Type = nameof(Type);
        public const string Status = nameof(Status);
        public const string CreatedAt = nameof(CreatedAt);

        public string GetDefault() => CreatedAt;
    }

    public BaseEntityId? StrategyId { get; set; }

    public string? Name { get; set; }

    public StrategyType? Type { get; set; }

    public StrategyStatus? Status { get; set; }

    public bool? IsEnabled { get; set; }
}