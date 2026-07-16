using Trading.Core.Contracts.RiskManagement.Queries;

using static Trading.Core.ApplicationService.RiskManagement.QueryHandlers.RiskProfileQueryFilter;

namespace Trading.Core.ApplicationService.RiskManagement.QueryHandlers;

public sealed class RiskProfileQueryFilter()
    : PagedSortableQueryFilter<SortRiskProfilePropertyNames>(new SortRiskProfilePropertyNames()),
      IQuery<PagedCollectionQueryResult<GetAllRiskProfileQueryResult>>,
      IQuery<GetRiskProfileByIdQueryResult>,
      IQuery<GetRiskStatisticsQueryResult>
{
    public sealed class SortRiskProfilePropertyNames : ISortablePropertyCollection
    {
        public const string RiskProfileId = nameof(RiskProfileId);
        public const string Name = nameof(Name);
        public const string RiskPerTrade = nameof(RiskPerTrade);
        public const string MaxDailyLoss = nameof(MaxDailyLoss);
        public const string CreatedAt = nameof(CreatedAt);

        public string GetDefault() => CreatedAt;
    }

    public BaseEntityId? RiskProfileId { get; set; }

    public string? Name { get; set; }

    public bool? IsEnabled { get; set; }
}