using Trading.Core.ApplicationService.Common.Models.Positions;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IPositionSizer
{
    Task<PositionSizingResult> CalculateAsync(
        PositionSizingRequest request,
        CancellationToken cancellationToken = default);
}