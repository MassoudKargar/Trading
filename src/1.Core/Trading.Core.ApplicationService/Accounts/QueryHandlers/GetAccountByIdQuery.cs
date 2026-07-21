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
        if (!query.AccountId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var account = await repository.GetByIdAsync(query.AccountId.Value, cancellationToken);

        return account is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(account);
    }
}
