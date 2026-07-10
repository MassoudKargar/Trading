using Base.Core.ApplicationServices.Queries.Extensions;
using Trading.Core.Contracts.Symbols;
using Trading.Core.Contracts.Symbols.Queries;

namespace Trading.Core.ApplicationService.Symbols.QueryHandlers;

public sealed class GetAllSymbolQueryHandler(
    BaseServices baseServices,
    ISymbolQueryRepository repository)
    : QueryHandler<SymbolQueryFilter,
        PagedCollectionQueryResult<GetAllSymbolQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetAllSymbolQueryResult>>> Handle(
        SymbolQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAll()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}