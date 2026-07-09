namespace Trading.Core.ApplicationService.Abstractions.Services;

public interface IEmailService
{
    Task SendAsync(
        string to,
        string subject,
        string body,
        CancellationToken cancellationToken = default);
}