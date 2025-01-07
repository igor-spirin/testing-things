using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Context.Configuration;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshTokenDb>
{
    public void Configure(EntityTypeBuilder<RefreshTokenDb> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id).IsUnique();
        
        builder.Property(x => x.Id).IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(x => x.AccountId).IsRequired();
        builder.Property(x => x.Token).IsRequired();

        builder.HasOne<AccountDb>(x => x.Account)
            .WithOne()
            .HasForeignKey<RefreshTokenDb>(x => x.AccountId)
            .IsRequired();
    }
}
