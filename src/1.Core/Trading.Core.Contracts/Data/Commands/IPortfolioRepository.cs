using Trading.Core.Domain.Portfolio;

namespace Trading.Core.Contracts.Data.Commands;

public interface IPortfolioRepository
    : ICommandRepository<Portfolio, BaseEntityId>
{
}