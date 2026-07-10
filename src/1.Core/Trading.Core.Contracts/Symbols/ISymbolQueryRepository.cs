using Trading.Core.Contracts.Symbols.Queries;

namespace Trading.Core.Contracts.Symbols;

public interface ISymbolQueryRepository
    : IQueryRepository
{
    IQueryable<GetAllSymbolQueryResult> GetAll();

    Task<GetSymbolByIdQueryResult?> GetByIdAsync(
        BaseEntityId symbolId,
        CancellationToken cancellationToken = default);

    Task<GetTradingHoursQueryResult?> GetTradingHoursAsync(
        BaseEntityId symbolId,
        CancellationToken cancellationToken = default);
}