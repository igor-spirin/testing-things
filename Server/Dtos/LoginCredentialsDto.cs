using Domain.Models.Auth;

namespace Server.Dtos;

public class LoginCredentialsDto
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}

public static class LoginCredentialsDtoExtensions
{
    public static LoginCredentials ToDomain(this LoginCredentialsDto dto)
    {
        return new LoginCredentials(dto.Login, dto.Password);
    }
}
