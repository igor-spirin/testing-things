using Domain.Enums;

namespace Models.Enums;

public enum AccountTypeDb
{
    Personal,
    Company,
    Admin
}

public static class AccountTypeDbExtensions
{
    public static AccountType ToDomain(this AccountTypeDb type) => type switch
    {
        AccountTypeDb.Personal => AccountType.Personal,
        AccountTypeDb.Company => AccountType.Company,
        AccountTypeDb.Admin => AccountType.Admin,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

    public static AccountTypeDb ToDb(this AccountType type) => type switch
    {
        AccountType.Personal => AccountTypeDb.Personal,
        AccountType.Company => AccountTypeDb.Company,
        AccountType.Admin => AccountTypeDb.Admin,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
}