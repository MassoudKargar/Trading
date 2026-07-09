using Trading.Core.ApplicationService.Common.Models.Accounts;

namespace Trading.Core.ApplicationService.Abstractions.Trading;


public interface IAccountProvider
{
    Task<AccountInfo> GetAccountAsync(
        CancellationToken cancellationToken = default);
}