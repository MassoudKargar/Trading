using Trading.Core.Domain.Accounts;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Data.Commands;

public interface IAccountRepository
    : ICommandRepository<Account, BaseEntityId>
{
}