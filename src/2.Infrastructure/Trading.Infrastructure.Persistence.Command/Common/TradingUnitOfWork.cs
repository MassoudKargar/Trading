using Base.Infra.Data.Sql.Commands;

using Trading.Core.Contracts.Common;

namespace Trading.Infrastructure.Persistence.Command.Common;

public class TradingUnitOfWork(TradingCommandDbContext dbContext) :
    BaseEntityFrameworkUnitOfWork<TradingCommandDbContext>(dbContext), ITradingUnitOfWork
{

}