using Trading.Core.Domain.RiskManagement;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Data.Commands;

public interface IRiskProfileRepository
    : ICommandRepository<RiskProfile, BaseEntityId>
{
}