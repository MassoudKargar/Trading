using Base.Core.Contracts.Data.Queries;

using Trading.Core.Contracts.Accounts.QueryResults;

namespace Trading.Core.Contracts.Data.Queries;

public interface IAccountQueryRepository : IQueryRepository
{
    IQueryable<GetAllAccountQueryResult> GetAll();

    Task<GetAccountByIdQueryResult?> GetByIdAsync(
        long accountId,
        CancellationToken cancellationToken = default);

    Task<GetAccountBalanceQueryResult?> GetBalanceAsync(
        long accountId,
        CancellationToken cancellationToken = default);

    Task<GetAccountMarginQueryResult?> GetMarginAsync(
        long accountId,
        CancellationToken cancellationToken = default);

    Task<GetAccountLeverageQueryResult?> GetLeverageAsync(
        long accountId,
        CancellationToken cancellationToken = default);
}