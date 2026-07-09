using Trading.Core.Domain.Strategies;

namespace Trading.Core.Contracts.Data.Commands;

public interface IStrategyRepository
    : ICommandRepository<Strategy, BaseEntityId>
{
}