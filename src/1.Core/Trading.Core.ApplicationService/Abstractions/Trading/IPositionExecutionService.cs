namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IPositionExecutionService
{
    Task ClosePositionAsync(
        string positionId,
        CancellationToken cancellationToken = default);

    Task ModifyPositionAsync(
        string positionId,
        decimal? stopLoss,
        decimal? takeProfit,
        CancellationToken cancellationToken = default);
}