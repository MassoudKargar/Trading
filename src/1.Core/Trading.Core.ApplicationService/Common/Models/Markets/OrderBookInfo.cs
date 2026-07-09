using Trading.Core.ApplicationService.Common.Models.Orders;

namespace Trading.Core.ApplicationService.Common.Models.Markets;

public sealed record OrderBookInfo(
    string Symbol,
    IReadOnlyCollection<OrderBookLevelInfo> Bids,
    IReadOnlyCollection<OrderBookLevelInfo> Asks,
    DateTime Timestamp);
public sealed record IndicatorSeries(
    string Name,
    IReadOnlyCollection<decimal> Values);