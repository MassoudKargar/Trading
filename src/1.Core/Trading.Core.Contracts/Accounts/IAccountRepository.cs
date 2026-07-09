using Trading.Core.Domain.Accounts;

namespace Trading.Core.Contracts.Accounts;

public interface IAccountRepository
    : ICommandRepository<Account, BaseEntityId>
{
}