using Trading.Core.ApplicationService.Common.Models.Risks;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IRiskManager
{
    Task<RiskCheckResult> CheckAsync(
        RiskCheckRequest request,
        CancellationToken cancellationToken = default);
}