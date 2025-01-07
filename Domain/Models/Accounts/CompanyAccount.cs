using Domain.Enums;

namespace Domain.Models.Accounts;

public class CompanyAccount : CoreAccount
{
    public CompanyAccount(long id, AccountType type, Role role, long coreId, string inn) : base(id, type, role, coreId)
    {
        Inn = inn;
    }

    public string Inn { get; set; }
}
