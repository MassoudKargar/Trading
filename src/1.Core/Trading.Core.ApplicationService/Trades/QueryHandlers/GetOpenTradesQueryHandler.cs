using Base.Core.ApplicationServices.Queries.Extensions;
using Trading.Core.Contracts.Trades.Queries;

namespace Trading.Core.ApplicationService.Trades.QueryHandlers;

public sealed class GetOpenTradeQueryHandler(
    BaseServices baseServices,
    ITradeQueryRepository repository)
    : QueryHandler<TradeQueryFilter, PagedCollectionQueryResult<GetOpenTradeQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetOpenTradeQueryResult>>> Handle(
        TradeQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAllOpen()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}