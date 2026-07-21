using Trading.Core.Contracts.Strategies;
using Trading.Core.Contracts.Strategies.Queries;

namespace Trading.Core.ApplicationService.Strategies.QueryHandlers;

public sealed class GetStrategyByIdQueryHandler(
    BaseServices baseServices,
    IStrategyQueryRepository repository)
    : QueryHandler<StrategyQueryFilter,
        GetStrategyByIdQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetStrategyByIdQueryResult>> Handle(
        StrategyQueryFilter query,
        CancellationToken cancellationToken)
    {
        if (!query.StrategyId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var strategy = await repository.GetByIdAsync(
            query.StrategyId.Value,
            cancellationToken);

        return strategy is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(strategy);
    }
}
