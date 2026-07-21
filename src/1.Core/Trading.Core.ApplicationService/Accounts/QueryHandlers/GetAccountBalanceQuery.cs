using Trading.Core.Contracts.Accounts;

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
        if (!query.AccountId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var balance = await repository.GetBalanceAsync(query.AccountId.Value, cancellationToken);

        return balance is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(balance);
    }
}
