using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain.Exceptions;
using Domain.Models.Accounts;
using Domain.Models.Auth;
using Domain.Models.Configs;
using Domain.Repositories;
using Domain.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AccountsService;

public class MyAccountsService : IAccountsService
{
    private readonly IAccountsRepository _accountsRepository;
    private readonly ITokensRepository _tokensRepository;
    private readonly JwtTokenConfig _jwtTokenConfig;
    private readonly ILogger<MyAccountsService> _logger;

    public MyAccountsService(IAccountsRepository accountsRepository,
        ITokensRepository tokensRepository,
        IOptions<JwtTokenConfig> jwtTokenConfig,
        ILogger<MyAccountsService> logger)
    {
        _accountsRepository = accountsRepository;
        _tokensRepository = tokensRepository;
        _jwtTokenConfig = jwtTokenConfig.Value;
        _logger = logger;
    }

    public async Task<Tokens?> LoginAsync(LoginCredentials credentials)
    {
        try
        {
            var passwordHashBytes = SHA384.HashData(Encoding.UTF8.GetBytes(credentials.Password));
            var passwordHash = Convert.ToBase64String(passwordHashBytes);

            var account = await _accountsRepository.GetAccountByCredentialsAsync(credentials.Login, passwordHash);
            if (account == null)
            {
                if (await _accountsRepository.AccountExistsAsync(credentials.Login))
                {
                    return null;
                }

                throw new InvalidAccountCredentialsException();
            }

            return await GenerateTokenPairAsync(account);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private string GenerateAccessTokenAsync(Account account)
    {
        var claims = new Claim[]
        {
            // new(JwtTokenClaims.AccountId, account.Id.ToString()),
            new(ClaimTypes.Role, account.Role.ToString()),
        };

        var keyBytes = Encoding.UTF8.GetBytes(_jwtTokenConfig.Key);
        var issuerSigningKey = new SymmetricSecurityKey(keyBytes);

        var jwt = new JwtSecurityToken(_jwtTokenConfig.Issuer,
            _jwtTokenConfig.Audience,
            claims,
            expires: DateTime.UtcNow.Add(_jwtTokenConfig.ExpiresIn),
            signingCredentials: new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private static string GenerateRefreshTokenAsync()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }

    private async Task<Tokens> GenerateTokenPairAsync(Account account)
    {
        var accessToken = GenerateAccessTokenAsync(account);
        var refreshToken = GenerateRefreshTokenAsync();
        var expiresIn = _jwtTokenConfig.ExpiresIn;

        // await _tokensRepository.AddTokenAsync(refreshToken);

        return new Tokens(accessToken, refreshToken, expiresIn);
    }

    // private async Task<AuthData> GenerateTokenPairAsync(string refreshToken)
    // {
    //     
    // }
}
