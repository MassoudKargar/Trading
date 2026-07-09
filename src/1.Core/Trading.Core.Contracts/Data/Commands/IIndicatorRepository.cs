using Trading.Core.Domain.Indicators;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Data.Commands;

public interface IIndicatorRepository
    : ICommandRepository<Indicator, BaseEntityId>
{
}