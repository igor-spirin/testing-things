namespace Domain.Models.Auth;

public class Tokens
{
    public Tokens(string accessToken, string refreshToken, TimeSpan expiresIn)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
    }

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public TimeSpan ExpiresIn { get; set; }
}
