using ISpire.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISpire.Infrastructure.Configurations;

public class AccountPermissionConfiguration : IEntityTypeConfiguration<AccountPermission>
{
    public void Configure(EntityTypeBuilder<AccountPermission> builder)
    {
        builder.HasKey(x => x.Guid);
        builder.HasOne(x => x.Account)
            .WithMany(a => a.AccountPermissions)
            .HasForeignKey(x => x.AccountGuid);
    }
}