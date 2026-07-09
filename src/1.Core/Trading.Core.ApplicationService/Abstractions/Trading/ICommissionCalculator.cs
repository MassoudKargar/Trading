using Trading.Core.ApplicationService.Common.Models.Commissions;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface ICommissionCalculator
{
    Task<CommissionCalculationResult> CalculateAsync(
        CommissionCalculationRequest request,
        CancellationToken cancellationToken = default);
}