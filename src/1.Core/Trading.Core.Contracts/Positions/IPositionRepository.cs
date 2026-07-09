using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Positions;

public interface IPositionRepository
    : ICommandRepository<Position, BaseEntityId>
{
}