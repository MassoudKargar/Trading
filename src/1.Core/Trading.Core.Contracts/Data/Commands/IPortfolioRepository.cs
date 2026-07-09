using Trading.Core.Domain.Portfolio;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Data.Commands;

public interface IPortfolioRepository
    : ICommandRepository<Portfolio, BaseEntityId>
{
}