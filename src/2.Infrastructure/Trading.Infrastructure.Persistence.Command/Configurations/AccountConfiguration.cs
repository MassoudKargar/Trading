using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Accounts;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class AccountConfiguration
    : ConfigurationBase<Account>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Provider)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.AccountNumber)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Equity)
            .HasPrecision(18, 8);

        builder.Property(x => x.MarginLevel)
            .HasPrecision(18, 8);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.OwnsOne(x => x.Balance, balance =>
        {
            balance.Property(x => x.Amount)
                .HasColumnName(nameof(Account.Balance))
                .HasPrecision(18, 8)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Margin, margin =>
        {
            margin.Property(x => x.Used)
                .HasColumnName("MarginUsed")
                .HasPrecision(18, 8);

            margin.Property(x => x.Free)
                .HasColumnName("MarginFree")
                .HasPrecision(18, 8);
        });

        builder.OwnsOne(x => x.Leverage, leverage =>
        {
            leverage.Property(x => x.Value)
                .HasColumnName(nameof(Account.Leverage))
                .IsRequired();
        });

        builder.HasIndex(x => x.AccountNumber)
            .IsUnique();
    }
}