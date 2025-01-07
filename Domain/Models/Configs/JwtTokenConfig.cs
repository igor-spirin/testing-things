namespace Domain.Models.Configs;

public class JwtTokenConfig
{
    public required string Audience { get; set; }
    public required string Issuer { get; set; }
    public required TimeSpan ExpiresIn { get; set; }
    public required string Key { get; set; }
}
