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
        return await ResultAsync(
            await repository.GetByIdAsync(
                query.SymbolId!,
                cancellationToken));
    }
}