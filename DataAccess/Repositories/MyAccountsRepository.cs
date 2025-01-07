using Context;
using Domain.Enums;
using Domain.Models.Accounts;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;

namespace Repositories;

public class MyAccountsRepository : IAccountsRepository
{
    private readonly MyContext _context;

    public MyAccountsRepository(MyContext context)
    {
        _context = context;
    }

    public async Task<Account?> GetAccountByIdAsync(long accountId)
    {
        var account = await _context.Accounts.AsNoTracking().SingleOrDefaultAsync(a => a.Id == accountId);

        return account?.ToDomain();
    }

    public async Task<TAccount?> GetAccountByIdAsync<TAccount>(long accountId) where TAccount : Account
    {
        var account = await GetAccountByIdAsync(accountId);
        if (account is TAccount typedAccount)
        {
            return typedAccount;
        }

        throw new Exception();
    }

    public async Task<AdminAccount?> GetAccountByCredentialsAsync(string login, string passwordHash)
    {
        var account = await _context.Accounts.AsNoTracking()
            .Where(a => a.Type == AccountType.Admin.ToDb())
            .SingleOrDefaultAsync(a => ((AdminAccountDb)a).Login == login
                && ((AdminAccountDb)a).PasswordHash == passwordHash);

        return ((AdminAccountDb?)account)?.ToDomain();
    }

    public async Task<bool> AccountExistsAsync(string login)
    {
        return await _context.Accounts.Where(a => a.Type == AccountType.Admin.ToDb())
            .AnyAsync(a => ((AdminAccountDb)a).Login == login);
    }
}
