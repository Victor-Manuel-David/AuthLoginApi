namespace AuthServer.Application.Auth;

public record LoginResult(string AccessToken, int ExpiresInSeconds);
