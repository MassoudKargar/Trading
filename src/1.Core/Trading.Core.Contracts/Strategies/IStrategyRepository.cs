using Trading.Core.Domain.Strategies;

namespace Trading.Core.Contracts.Strategies;

public interface IStrategyRepository
    : ICommandRepository<Strategy, BaseEntityId>
{
}