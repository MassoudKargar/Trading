namespace Trading.Core.Contracts.Portfolio;

public interface IPortfolioRepository
    : ICommandRepository<Domain.Portfolio.Portfolio, BaseEntityId>
{
}