namespace Trading.Core.ApplicationService.Abstractions.Services;

public interface IFileStorageService
{
    Task<string> SaveAsync(
        Stream stream,
        string fileName,
        CancellationToken cancellationToken = default);

    Task<Stream> OpenReadAsync(
        string path,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        string path,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        string path,
        CancellationToken cancellationToken = default);
}