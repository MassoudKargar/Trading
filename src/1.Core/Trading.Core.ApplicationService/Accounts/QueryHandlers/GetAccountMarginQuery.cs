using Trading.Core.Contracts.Accounts;

namespace Trading.Core.ApplicationService.Accounts.QueryHandlers;

public sealed class GetAccountMarginQuery(
    BaseServices baseServices,
    IAccountQueryRepository repository)
    : QueryHandler<AccountQueryFilter, GetAccountMarginQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetAccountMarginQueryResult>> Handle(
        AccountQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetMarginAsync(query.AccountId!.Value, cancellationToken));
    }
}