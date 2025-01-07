using Domain.Enums;

namespace Models.Enums;

public enum RoleDb
{
    Default,
    Personal,
    CompanyBasic,
    CompanyExtended,
    Admin
}

public static class RoleDbExtensions
{
    public static Role ToDomain(this RoleDb role) => role switch
    {
        RoleDb.Default => Role.Default,
        RoleDb.Personal => Role.Personal,
        RoleDb.CompanyBasic => Role.CompanyBasic,
        RoleDb.CompanyExtended => Role.CompanyExtended,
        RoleDb.Admin => Role.Admin,
        _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
    };
}