namespace AuthServer.Infrastructure.Configuration;

public class JwtOptions
{
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string SigningKey { get; set; } = default!;
    public int ExpiresInSeconds { get; set; } = 3600;
}

