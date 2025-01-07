using Domain.Enums;

namespace Domain.Models.Accounts;

public class PersonalAccount : CoreAccount
{
    public PersonalAccount(long id, AccountType type, Role role, long coreId, string email) : base(id, type, role, coreId)
    {
        Email = email;
    }

    public string Email { get; set; }
}
