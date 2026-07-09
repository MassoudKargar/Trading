using Base.Core.ApplicationServices.Queries.Extensions;
using Trading.Core.Contracts.Trades.Queries;

namespace Trading.Core.ApplicationService.Trades.QueryHandlers;

public sealed class GetAllTradeQueryHandler(
    BaseServices baseServices,
    ITradeQueryRepository repository)
    : QueryHandler<TradeQueryFilter, PagedCollectionQueryResult<GetAllTradeQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetAllTradeQueryResult>>> Handle(
        TradeQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAll()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}