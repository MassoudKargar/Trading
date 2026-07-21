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
        if (!query.TradeId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var trade = await repository.GetByIdAsync(
            query.TradeId.Value,
            cancellationToken);

        return trade is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(trade);
    }
}
