using Domain.Models;
using Domain.Models.Accounts;

namespace Domain.Repositories;

public interface IAccountsRepository
{
    Task<AdminAccount?> GetAccountByCredentialsAsync(string login, string passwordHash);
    Task<bool> AccountExistsAsync(string login);
}
