using Trading.Core.ApplicationService.Common.Models.Markets;
using Trading.Core.Resources.Enumerations.Markets;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IMarketDataProvider
{
    Task<TickInfo> GetTickAsync(
        string symbol,
        CancellationToken cancellationToken = default);

    Task<CandleInfo> GetLastCandleAsync(
        string symbol,
        TimeFrame timeFrame,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<CandleInfo>> GetCandlesAsync(
        string symbol,
        TimeFrame timeFrame,
        int count,
        CancellationToken cancellationToken = default);

    Task<OrderBookInfo> GetOrderBookAsync(
        string symbol,
        CancellationToken cancellationToken = default);
}