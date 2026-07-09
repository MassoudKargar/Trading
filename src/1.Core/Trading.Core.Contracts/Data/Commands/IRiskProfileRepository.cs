using Trading.Core.Domain.RiskManagement;

namespace Trading.Core.Contracts.Data.Commands;

public interface IRiskProfileRepository
    : ICommandRepository<RiskProfile, BaseEntityId>
{
}