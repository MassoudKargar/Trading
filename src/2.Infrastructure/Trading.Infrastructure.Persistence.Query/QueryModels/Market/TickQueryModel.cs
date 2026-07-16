using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Market;

public sealed class TickQueryModel
{
    public BaseEntityId Id { get; set; }

    public string Symbol { get; set; } = default!;

    public decimal Bid { get; set; }

    public decimal Ask { get; set; }

    public decimal Last { get; set; }

    public decimal? Volume { get; set; }

    public DateTime Time { get; set; }

    public DateTime ReceivedAt { get; set; }
}