using Domain.Enums;

namespace Domain.Models.Accounts;

public abstract class CoreAccount : Account
{
    protected CoreAccount(long id, AccountType type, Role role, long coreId) : base(id, type, role)
    {
        CoreId = coreId;
    }

    public long CoreId { get; set; }
}
