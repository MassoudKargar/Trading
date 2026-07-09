using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Data.Commands;

public interface IPositionRepository
    : ICommandRepository<Position, BaseEntityId>
{
}