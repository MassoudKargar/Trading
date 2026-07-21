using Trading.Core.Contracts.Accounts;

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
        if (!query.AccountId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var leverage = await repository.GetLeverageAsync(query.AccountId.Value, cancellationToken);

        return leverage is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(leverage);
    }
}
