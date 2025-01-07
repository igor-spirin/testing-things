using Domain.Models.Accounts;
using Models.Enums;

namespace Models;

public class CompanyAccountDb : CoreAccountDb
{
    public CompanyAccountDb(long id,
        AccountTypeDb type,
        RoleDb role,
        long coreId,
        string inn)
        : base(id,
            type,
            role,
            coreId)
    {
        Inn = inn;
    }

    public string Inn { get; set; }
}

public static class CompanyAccountDbExtensions
{
    public static CompanyAccount ToDomain(this CompanyAccountDb account)
    {
        return new CompanyAccount(account.Id,
            account.Type.ToDomain(),
            account.Role.ToDomain(),
            account.CoreId,
            account.Inn);
    }
}
