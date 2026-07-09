using Trading.Core.Contracts.Positions;
using Trading.Core.Contracts.Positions.Queries;

namespace Trading.Core.ApplicationService.Positions.QueryHandlers;

public sealed class GetPositionByIdQueryHandler(
    BaseServices baseServices,
    IPositionQueryRepository repository)
    : QueryHandler<PositionQueryFilter, GetPositionByIdQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetPositionByIdQueryResult>> Handle(
        PositionQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetByIdAsync(
                query.PositionId.Value,
                cancellationToken));
    }
}