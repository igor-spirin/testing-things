using Domain.Models.Auth;

namespace Server.Dtos;

public class TokensDto
{
    public TokensDto(string accessToken, string refreshToken, TimeSpan expiresIn)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
    }

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public TimeSpan ExpiresIn { get; set; }
}

public static class TokensDtoExtensions
{
    public static TokensDto ToDto(this Tokens tokens)
    {
        return new TokensDto(tokens.AccessToken, tokens.RefreshToken, tokens.ExpiresIn);
    }
}