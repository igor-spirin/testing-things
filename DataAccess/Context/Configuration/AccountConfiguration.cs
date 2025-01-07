using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Models.Enums;

namespace Context.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<AccountDb>
{
    public void Configure(EntityTypeBuilder<AccountDb> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.HasDiscriminator<AccountTypeDb>("Type")
            .HasValue<PersonalAccountDb>(AccountTypeDb.Personal)
            .HasValue<CompanyAccountDb>(AccountTypeDb.Company)
            .HasValue<AdminAccountDb>(AccountTypeDb.Admin);
    }
}