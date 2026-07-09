using Trading.Core.ApplicationService.Common.Models.Markets;
using Trading.Core.Resources.Enumerations;

namespace Trading.Core.ApplicationService.Common.Models.Indicators;

public sealed record IndicatorResult(
    IndicatorType Indicator,
    IReadOnlyCollection<IndicatorSeries> Series);