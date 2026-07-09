using Trading.Core.ApplicationService.Common.Models.Markets;
using Trading.Core.Resources.Enumerations;

namespace Trading.Core.ApplicationService.Common.Models.Indicators;

public sealed record IndicatorRequest(
    IndicatorType Indicator,
    IReadOnlyCollection<CandleInfo> Candles,
    IReadOnlyDictionary<string, decimal> Parameters);