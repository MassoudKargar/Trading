using Trading.Core.Resources.Enumerations.Markets;

namespace Trading.Core.ApplicationService.Common.Models.Markets;

public sealed record CandleInfo(
    string Symbol,
    TimeFrame TimeFrame,
    DateTime OpenTime,
    decimal Open,
    decimal High,
    decimal Low,
    decimal Close,
    decimal Volume);