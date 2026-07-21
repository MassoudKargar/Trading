using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Accounts;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class AccountQueryConfiguration
    : QueryConfigurationBase<AccountQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<AccountQueryModel> builder)
    {
        builder.ToTable("Accounts", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Provider)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.AccountNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Balance)
            .HasPrecision(18, 8);

        builder.Property(x => x.Equity)
            .HasPrecision(18, 8);

        builder.Property(x => x.MarginUsed)
            .HasPrecision(18, 8);

        builder.Property(x => x.MarginFree)
            .HasPrecision(18, 8);

        builder.Property(x => x.MarginLevel)
            .HasPrecision(18, 8);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.HasIndex(x => x.AccountNumber)
            .IsUnique();

        builder.HasIndex(x => x.Provider);

        builder.HasIndex(x => x.IsActive);
    }
}
