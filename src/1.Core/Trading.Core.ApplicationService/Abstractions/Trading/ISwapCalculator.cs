using Trading.Core.ApplicationService.Common.Models.Swaps;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface ISwapCalculator
{
    Task<SwapCalculationResult> CalculateAsync(
        SwapCalculationRequest request,
        CancellationToken cancellationToken = default);
}