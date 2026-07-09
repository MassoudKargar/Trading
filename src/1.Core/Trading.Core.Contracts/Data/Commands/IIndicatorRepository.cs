using Trading.Core.Domain.Indicators;

namespace Trading.Core.Contracts.Data.Commands;

public interface IIndicatorRepository
    : ICommandRepository<Indicator, BaseEntityId>
{
}