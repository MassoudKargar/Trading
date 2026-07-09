using Trading.Core.ApplicationService.Common.Models.Indicators;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IIndicatorCalculator
{
    Task<IndicatorResult> CalculateAsync(
        IndicatorRequest request,
        CancellationToken cancellationToken = default);
}