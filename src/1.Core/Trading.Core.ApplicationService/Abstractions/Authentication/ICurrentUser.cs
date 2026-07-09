namespace Trading.Core.ApplicationService.Abstractions.Authentication;

public interface ICurrentUser
{
    bool IsAuthenticated { get; }

    string? UserId { get; }

    string? UserName { get; }

    string? Email { get; }

    Guid? AccountId { get; }

    IReadOnlyCollection<string> Roles { get; }

    bool IsInRole(string role);
}