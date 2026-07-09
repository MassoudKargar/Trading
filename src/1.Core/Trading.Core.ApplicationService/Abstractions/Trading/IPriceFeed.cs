using Trading.Core.ApplicationService.Common.Models.Markets;
using Trading.Core.Domain.Enumerations.Markets;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IPriceFeed
{
    IAsyncEnumerable<TickInfo> SubscribeTicksAsync(
        string symbol,
        CancellationToken cancellationToken = default);

    IAsyncEnumerable<CandleInfo> SubscribeCandlesAsync(
        string symbol,
        TimeFrame timeFrame,
        CancellationToken cancellationToken = default);
}