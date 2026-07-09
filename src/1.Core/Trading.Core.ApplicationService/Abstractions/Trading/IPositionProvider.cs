using Trading.Core.ApplicationService.Common.Models.Positions;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IPositionProvider
{
    Task<PositionInfo?> GetPositionAsync(
        string positionId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<PositionInfo>> GetOpenPositionsAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<PositionInfo>> GetPositionsAsync(
        string symbol,
        CancellationToken cancellationToken = default);
}