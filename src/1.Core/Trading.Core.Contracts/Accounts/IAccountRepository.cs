using Trading.Core.Domain.Accounts;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Accounts;

public interface IAccountRepository
    : ICommandRepository<Account, BaseEntityId>
{
}