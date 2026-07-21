using Trading.Core.Contracts.Symbols;
using Trading.Core.Contracts.Symbols.Queries;

namespace Trading.Core.ApplicationService.Symbols.QueryHandlers;

public sealed class GetSymbolByIdQueryHandler(
    BaseServices baseServices,
    ISymbolQueryRepository repository)
    : QueryHandler<SymbolQueryFilter,
        GetSymbolByIdQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetSymbolByIdQueryResult>> Handle(
        SymbolQueryFilter query,
        CancellationToken cancellationToken)
    {
        if (!query.SymbolId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var symbol = await repository.GetByIdAsync(
            query.SymbolId.Value,
            cancellationToken);

        return symbol is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(symbol);
    }
}
