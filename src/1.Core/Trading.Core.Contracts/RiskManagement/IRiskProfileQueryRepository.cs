using Trading.Core.Contracts.RiskManagement.Queries;

namespace Trading.Core.Contracts.RiskManagement;

public interface IRiskProfileQueryRepository : IQueryRepository
{
    IQueryable<GetAllRiskProfileQueryResult> GetAll();

    Task<GetRiskProfileByIdQueryResult?> GetByIdAsync(
        BaseEntityId riskProfileId,
        CancellationToken cancellationToken = default);

    Task<GetRiskStatisticsQueryResult?> GetStatisticsAsync(
        BaseEntityId riskProfileId,
        CancellationToken cancellationToken = default);
}