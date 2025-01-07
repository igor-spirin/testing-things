using Domain.Models.Accounts;
using Models.Enums;

namespace Models;

public class PersonalAccountDb : CoreAccountDb
{
    public PersonalAccountDb(long id,
        AccountTypeDb type,
        RoleDb role,
        long coreId,
        string email) : base(id,
        type,
        role,
        coreId)
    {
        Email = email;
    }

    public string Email { get; set; }
}

public static class PersonalAccountDbExtensions
{
    public static PersonalAccount ToDomain(this PersonalAccountDb account)
    {
        return new PersonalAccount(account.Id,
            account.Type.ToDomain(),
            account.Role.ToDomain(),
            account.CoreId,
            account.Email);
    }
}
