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
        if (!query.AccountId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var margin = await repository.GetMarginAsync(query.AccountId.Value, cancellationToken);

        return margin is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(margin);
    }
}
