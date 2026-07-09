using Base.Infra.Data.Sql.Commands;
using Trading.Core.Contracts.Common;

namespace Trading.Infra.Data.Sql.Commands.Common;

public class TradingUnitOfWork(TradingCommandDbContext dbContext) :
    BaseEntityFrameworkUnitOfWork<TradingCommandDbContext>(dbContext), ITradingUnitOfWork
{

}