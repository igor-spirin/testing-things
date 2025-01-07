using Domain.Enums;

namespace Domain.Models.Accounts;

public class AdminAccount : Account
{
    public AdminAccount(long id, AccountType type, Role role, string login) : base(id, type, role)
    {
        Login = login;
    }

    public string Login { get; set; }
}
