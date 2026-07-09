using Trading.Core.Domain.Trades;

namespace Trading.Core.Contracts.Trades;

public interface ITradeRepository
    : ICommandRepository<Trade, BaseEntityId>
{
}