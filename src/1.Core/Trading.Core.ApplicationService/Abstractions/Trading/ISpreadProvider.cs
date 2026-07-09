using Trading.Core.ApplicationService.Common.Models.Spreads;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface ISpreadProvider
{
    Task<SpreadInfo> GetSpreadAsync(
        string symbol,
        CancellationToken cancellationToken = default);
}