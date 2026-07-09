namespace Trading.Core.ApplicationService.Abstractions.Authentication;

public interface ITokenProvider
{
    string CreateAccessToken(
        ICurrentUser currentUser);

    string CreateRefreshToken();

    DateTime GetAccessTokenExpiration();

    DateTime GetRefreshTokenExpiration();
}