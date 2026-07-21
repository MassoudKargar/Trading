using Trading.Core.Contracts.Symbols;
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
        if (!query.SymbolId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var tradingHours = await repository.GetTradingHoursAsync(
            query.SymbolId.Value,
            cancellationToken);

        return tradingHours is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(tradingHours);
    }
}
