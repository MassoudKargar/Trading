namespace Trading.Core.ApplicationService.Accounts.QueryHandlers;

public sealed class GetAccountLeverageQuery(
    BaseServices baseServices,
    IAccountQueryRepository repository)
    : QueryHandler<AccountQueryFilter, GetAccountLeverageQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetAccountLeverageQueryResult>> Handle(
        AccountQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetLeverageAsync(query.AccountId!.Value, cancellationToken));
    }
}