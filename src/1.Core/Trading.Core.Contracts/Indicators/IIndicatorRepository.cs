using Trading.Core.Domain.Indicators;

namespace Trading.Core.Contracts.Indicators;

public interface IIndicatorRepository
    : ICommandRepository<Indicator, BaseEntityId>
{
}