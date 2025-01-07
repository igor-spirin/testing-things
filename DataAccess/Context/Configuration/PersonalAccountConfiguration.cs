using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Context.Configuration;

public class PersonalAccountConfiguration : IEntityTypeConfiguration<PersonalAccountDb>
{
    public void Configure(EntityTypeBuilder<PersonalAccountDb> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();
    }
}
