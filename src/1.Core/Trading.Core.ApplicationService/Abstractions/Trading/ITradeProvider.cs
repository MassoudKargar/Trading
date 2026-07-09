using Trading.Core.ApplicationService.Common.Models.Trades;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface ITradeProvider
{
    Task<TradeInfo?> GetTradeAsync(
        string tradeId,
        CancellationToken cancellationToken = default);


    Task<IReadOnlyCollection<TradeInfo>> GetTradesAsync(
        string symbol,
        CancellationToken cancellationToken = default);


    Task<IReadOnlyCollection<TradeInfo>> GetTradesByOrderAsync(
        string orderId,
        CancellationToken cancellationToken = default);


    Task<IReadOnlyCollection<TradeInfo>> GetRecentTradesAsync(
        int limit,
        CancellationToken cancellationToken = default);
}