using Base.Core.ApplicationServices.Queries.Extensions;

namespace Trading.Core.ApplicationService.Accounts.QueryHandlers;

public sealed class GetAllAccountQuery(
    BaseServices baseServices,
    IAccountQueryRepository repository)
    : QueryHandler<AccountQueryFilter, PagedCollectionQueryResult<GetAllAccountQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetAllAccountQueryResult>>> Handle(
        AccountQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAll()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}