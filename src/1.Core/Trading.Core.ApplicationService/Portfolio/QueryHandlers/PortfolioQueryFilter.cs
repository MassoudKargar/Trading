using Trading.Core.Contracts.Portfolio.Queries;

namespace Trading.Core.ApplicationService.Portfolio.QueryHandlers;

public sealed class PortfolioQueryFilter()
    : PagedSortableQueryFilter<PortfolioQueryFilter.SortPortfolioPropertyNames>(new SortPortfolioPropertyNames()),
        IQuery<PagedCollectionQueryResult<GetAllPortfolioQueryResult>>,
        IQuery<GetPortfolioByIdQueryResult>,
        IQuery<GetPortfolioStatisticsQueryResult>
{
    public sealed class SortPortfolioPropertyNames : ISortablePropertyCollection
    {
        public const string PortfolioId = nameof(PortfolioId);
        public const string AccountId = nameof(AccountId);
        public const string Balance = nameof(Balance);
        public const string Equity = nameof(Equity);
        public const string TotalProfit = nameof(TotalProfit);
        public const string CreatedAt = nameof(CreatedAt);

        public string GetDefault() => CreatedAt;
    }

    public BaseEntityId? PortfolioId { get; set; }

    public BaseEntityId? AccountId { get; set; }
}