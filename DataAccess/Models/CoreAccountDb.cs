using Models.Enums;

namespace Models;

public abstract class CoreAccountDb : AccountDb
{
    protected CoreAccountDb(long id, AccountTypeDb type, RoleDb role, long coreId) : base(id, type, role)
    {
        CoreId = coreId;
    }

    public long CoreId { get; set; }
}
