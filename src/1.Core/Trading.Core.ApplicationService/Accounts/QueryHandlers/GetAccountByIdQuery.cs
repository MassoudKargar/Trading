using Trading.Core.Contracts.Accounts;

namespace Trading.Core.ApplicationService.Accounts.QueryHandlers;

public sealed class GetAccountByIdQuery(
    BaseServices baseServices,
    IAccountQueryRepository repository)
    : QueryHandler<AccountQueryFilter, GetAccountByIdQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetAccountByIdQueryResult>> Handle(
        AccountQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetByIdAsync(query.AccountId!.Value, cancellationToken));
    }
}