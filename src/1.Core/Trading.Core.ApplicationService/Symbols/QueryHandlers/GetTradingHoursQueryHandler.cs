using Trading.Core.Contracts.Symbols.Queries;

namespace Trading.Core.ApplicationService.Symbols.QueryHandlers;

public sealed class GetTradingHoursQueryHandler(
    BaseServices baseServices,
    ISymbolQueryRepository repository)
    : QueryHandler<SymbolQueryFilter,
        GetTradingHoursQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetTradingHoursQueryResult>> Handle(
        SymbolQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetTradingHoursAsync(
                query.SymbolId!,
                cancellationToken));
    }
}