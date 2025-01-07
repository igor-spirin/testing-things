using Domain.Models;
using Domain.Models.Accounts;
using Models.Enums;

namespace Models;

public abstract class AccountDb
{
    protected AccountDb(long id, AccountTypeDb type, RoleDb role)
    {
        Id = id;
        Type = type;
        Role = role;
    }

    public long Id { get; set; }
    public AccountTypeDb Type { get; set; }
    public RoleDb Role { get; set; }
}

public static class AccountDbExtensions
{
    public static Account ToDomain(this AccountDb account) => account switch
    {
        PersonalAccountDb personalAccount => personalAccount.ToDomain(),
        CompanyAccountDb companyAccount => companyAccount.ToDomain(),
        AdminAccountDb admin => admin.ToDomain(),
        _ => throw new Exception()
    };
}
