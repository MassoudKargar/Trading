using Trading.Core.Contracts.Strategies;
using Trading.Core.Contracts.Strategies.Queries;

namespace Trading.Core.ApplicationService.Strategies.QueryHandlers;

public sealed class GetStrategyStatusQueryHandler(
    BaseServices baseServices,
    IStrategyQueryRepository repository)
    : QueryHandler<StrategyQueryFilter,
        GetStrategyStatusQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetStrategyStatusQueryResult>> Handle(
        StrategyQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetStatusAsync(
                query.StrategyId.Value!,
                cancellationToken));
    }
}