using Trading.Core.Domain.Trades;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Data.Commands;

public interface ITradeRepository
    : ICommandRepository<Trade, BaseEntityId>
{
}