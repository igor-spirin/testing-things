using Domain.Enums;

namespace Domain.Models.Accounts;

public abstract class Account
{
    protected Account(long id, AccountType type, Role role)
    {
        Id = id;
        Type = type;
        Role = role;
    }

    public long Id { get; set; }
    public AccountType Type { get; set; }
    public Role Role { get; set; }
}