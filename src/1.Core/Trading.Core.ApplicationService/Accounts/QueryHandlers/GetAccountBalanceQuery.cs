namespace Trading.Core.ApplicationService.Accounts.QueryHandlers;

public sealed class GetAccountBalanceQuery(
    BaseServices baseServices,
    IAccountQueryRepository repository)
    : QueryHandler<AccountQueryFilter, GetAccountBalanceQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetAccountBalanceQueryResult>> Handle(
        AccountQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetBalanceAsync(query.AccountId!.Value, cancellationToken));
    }
}