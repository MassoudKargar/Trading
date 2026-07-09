using Trading.Core.Contracts.Trades.Queries;

namespace Trading.Core.ApplicationService.Trades.QueryHandlers;

public sealed class GetTradeByIdQueryHandler(
    BaseServices baseServices,
    ITradeQueryRepository repository)
    : QueryHandler<TradeQueryFilter, GetTradeByIdQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetTradeByIdQueryResult>> Handle(
        TradeQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetByIdAsync(
                query.TradeId!,
                cancellationToken));
    }
}