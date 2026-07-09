using Trading.Core.ApplicationService.Common.Models.Trading;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface ITradingCalendar
{
    Task<bool> IsMarketOpenAsync(string symbol, CancellationToken cancellationToken = default);
    Task<TradingSessionInfo> GetCurrentSessionAsync(string symbol, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TradingSessionInfo>> GetSessionsAsync(string symbol, CancellationToken cancellationToken = default);
}