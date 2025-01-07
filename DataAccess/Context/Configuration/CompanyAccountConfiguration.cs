using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Context.Configuration;

public class CompanyAccountConfiguration : IEntityTypeConfiguration<CompanyAccountDb>
{
    public void Configure(EntityTypeBuilder<CompanyAccountDb> builder)
    {
        builder.HasIndex(x => x.Inn).IsUnique();

    }
}
