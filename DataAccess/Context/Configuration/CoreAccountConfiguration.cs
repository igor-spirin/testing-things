using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Context.Configuration;

public class CoreAccountConfiguration : IEntityTypeConfiguration<CoreAccountDb>
{
    public void Configure(EntityTypeBuilder<CoreAccountDb> builder)
    {
        builder.HasIndex(x => x.CoreId).IsUnique();
    }
}
