namespace Trading.Core.Contracts.Trades;

public interface ITradeQueryRepository
    : IQueryRepository
{
    IQueryable<GetAllTradeQueryResult> GetAll();

    IQueryable<GetOpenTradeQueryResult> GetAllOpen();

    Task<GetTradeByIdQueryResult?> GetByIdAsync(
        BaseEntityId tradeId,
        CancellationToken cancellationToken = default);
}