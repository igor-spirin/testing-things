using Domain.Models.Accounts;
using Models.Enums;

namespace Models;

public class AdminAccountDb : AccountDb
{
    public AdminAccountDb(long id,
        AccountTypeDb type,
        RoleDb role,
        string login,
        string passwordHash)
        : base(id,
            type,
            role)
    {
        Login = login;
        PasswordHash = passwordHash;
    }

    public string Login { get; set; }

    public string PasswordHash { get; set; }
}

public static class AdminAccountDbExtensions
{
    public static AdminAccount ToDomain(this AdminAccountDb account)
    {
        return new AdminAccount(account.Id,
            account.Type.ToDomain(),
            account.Role.ToDomain(),
            account.Login);
    }
}
