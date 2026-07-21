using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Market;

public sealed class CandleQueryModel
{
    public BaseEntityId Id { get; set; }

    public string Symbol { get; set; } = default!;

    public string TimeFrame { get; set; } = default!;

    public DateTime OpenTime { get; set; }

    public DateTime? CloseTime { get; set; }

    public decimal Open { get; set; }

    public decimal High { get; set; }

    public decimal Low { get; set; }

    public decimal Close { get; set; }

    public decimal Volume { get; set; }

    public bool IsClosed { get; set; }
}