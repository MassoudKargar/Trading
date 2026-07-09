using Trading.Core.ApplicationService.Common.Models.Markets;
using Trading.Core.Resources.Enumerations.Markets;

namespace Trading.Core.ApplicationService.Common.Models.Strategies;

public sealed record StrategyExecutionRequest(
    string StrategyName,
    string Symbol,
    TimeFrame TimeFrame,
    IReadOnlyCollection<CandleInfo> Candles);