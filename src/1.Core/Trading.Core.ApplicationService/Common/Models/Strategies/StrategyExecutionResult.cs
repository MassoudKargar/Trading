using Trading.Core.Domain.Enumerations;

namespace Trading.Core.ApplicationService.Common.Models.Strategies;

public sealed record StrategyExecutionResult(
    bool HasSignal,
    SignalType Signal,
    decimal? EntryPrice,
    decimal? StopLoss,
    decimal? TakeProfit,
    string? Comment);