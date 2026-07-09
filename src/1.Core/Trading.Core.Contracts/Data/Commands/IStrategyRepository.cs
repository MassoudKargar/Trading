using Trading.Core.Domain.Strategies;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Data.Commands;

public interface IStrategyRepository
    : ICommandRepository<Strategy, BaseEntityId>
{
}