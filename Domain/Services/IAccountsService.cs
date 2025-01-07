using Domain.Models;
using Domain.Models.Auth;

namespace Domain.Services;

public interface IAccountsService
{
    Task<Tokens?> LoginAsync(LoginCredentials credentials);
}
