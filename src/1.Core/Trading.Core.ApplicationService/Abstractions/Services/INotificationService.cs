namespace Trading.Core.ApplicationService.Abstractions.Services;

public interface INotificationService
{
    Task SendAsync(
        string title,
        string message,
        CancellationToken cancellationToken = default);
}