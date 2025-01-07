using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Context.Configuration;

public class AdminAccountConfiguration : IEntityTypeConfiguration<AdminAccountDb>
{
    public void Configure(EntityTypeBuilder<AdminAccountDb> builder)
    {
        builder.HasIndex(x => x.Login).IsUnique();
    }
}
