using Microsoft.EntityFrameworkCore;
using Models;

namespace Context;

public class MyContext : DbContext
{
    public DbSet<AccountDb> Accounts { get; set; }

    protected MyContext()
    {
    }

    public MyContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyContext).Assembly);
    }
}
