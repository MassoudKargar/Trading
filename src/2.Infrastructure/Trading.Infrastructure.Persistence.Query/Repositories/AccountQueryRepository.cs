using Trading.Core.Contracts.Accounts;
using Trading.Core.Contracts.Accounts.QueryResults;

namespace Trading.Infrastructure.Persistence.Query.Repositories;

public sealed class AccountQueryRepository(TradingQueryDbContext dbContext)
    : IAccountQueryRepository
{
    public IQueryable<GetAllAccountQueryResult> GetAll()
        => dbContext.Accounts
            .AsNoTracking()
            .Select(x => new GetAllAccountQueryResult
            {
                AccountId = x.Id.Value,
                Provider = x.Provider,
                AccountNumber = x.AccountNumber,
                Currency = x.Currency,
                Balance = x.Balance,
                Equity = x.Equity,
                FreeMargin = x.MarginFree,
                UsedMargin = x.MarginUsed,
                MarginLevel = x.MarginLevel,
                Leverage = x.Leverage,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt
            });

    public Task<GetAccountByIdQueryResult?> GetByIdAsync(
        long accountId,
        CancellationToken cancellationToken = default)
        => dbContext.Accounts
            .AsNoTracking()
            .Where(x => x.Id == accountId)
            .Select(x => new GetAccountByIdQueryResult
            {
                AccountId = x.Id.Value,
                Provider = x.Provider,
                AccountNumber = x.AccountNumber,
                Currency = x.Currency,
                Balance = x.Balance,
                Equity = x.Equity,
                FreeMargin = x.MarginFree,
                UsedMargin = x.MarginUsed,
                MarginLevel = x.MarginLevel,
                Leverage = x.Leverage,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt,
                LastActivity = x.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

    public Task<GetAccountBalanceQueryResult?> GetBalanceAsync(
        long accountId,
        CancellationToken cancellationToken = default)
        => dbContext.Accounts
            .AsNoTracking()
            .Where(x => x.Id == accountId)
            .Select(x => new GetAccountBalanceQueryResult
            {
                AccountId = x.Id.Value,
                Balance = x.Balance,
                Equity = x.Equity,
                Profit = x.Equity - x.Balance,
                Credit = 0,
                Currency = x.Currency
            })
            .FirstOrDefaultAsync(cancellationToken);

    public Task<GetAccountMarginQueryResult?> GetMarginAsync(
        long accountId,
        CancellationToken cancellationToken = default)
        => dbContext.Accounts
            .AsNoTracking()
            .Where(x => x.Id == accountId)
            .Select(x => new GetAccountMarginQueryResult
            {
                AccountId = x.Id.Value,
                UsedMargin = x.MarginUsed,
                FreeMargin = x.MarginFree,
                MarginLevel = x.MarginLevel,
                StopOutLevel = 0
            })
            .FirstOrDefaultAsync(cancellationToken);

    public Task<GetAccountLeverageQueryResult?> GetLeverageAsync(
        long accountId,
        CancellationToken cancellationToken = default)
        => dbContext.Accounts
            .AsNoTracking()
            .Where(x => x.Id == accountId)
            .Select(x => new GetAccountLeverageQueryResult
            {
                AccountId = x.Id.Value,
                Leverage = x.Leverage,
                MaxLot = 0,
                MinLot = 0,
                LotStep = 0
            })
            .FirstOrDefaultAsync(cancellationToken);
}
