using Trading.Core.Domain.RiskManagement;

namespace Trading.Core.Contracts.RiskManagement;

public interface IRiskProfileRepository
    : ICommandRepository<RiskProfile, BaseEntityId>
{
}