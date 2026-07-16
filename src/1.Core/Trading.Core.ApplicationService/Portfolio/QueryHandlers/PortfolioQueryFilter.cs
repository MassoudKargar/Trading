using Base.Core.RequestResponse.Queries;

using Trading.Core.Contracts.Portfolio.Queries;
using Trading.Core.Resources.Shared.Base;

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

        public const string CreatedAt = nameof(CreatedAt);

        public const string UpdatedAt = nameof(UpdatedAt);

        public const string Balance = nameof(Balance);

        public const string Equity = nameof(Equity);

        public const string FloatingProfit = nameof(FloatingProfit);

        public const string RealizedProfit = nameof(RealizedProfit);

        public const string Drawdown = nameof(Drawdown);

        public string GetDefault()
            => CreatedAt;
    }

    public BaseEntityId? PortfolioId { get; init; }

    public BaseEntityId? AccountId { get; init; }
}