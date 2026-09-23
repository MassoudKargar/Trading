using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Portfolio;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class PortfolioConfiguration
    : ConfigurationBase<Portfolio>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Portfolio> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.AccountId)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.OwnsOne(x => x.Statistics, stats =>
        {
            stats.Property(x => x.Balance)
                .HasColumnName("Statistics_Balance")
                .HasPrecision(18, 8)
                .IsRequired();

            stats.Property(x => x.Equity)
                .HasColumnName("Statistics_Equity")
                .HasPrecision(18, 8)
                .IsRequired();

            stats.Property(x => x.FloatingProfit)
                .HasColumnName("Statistics_FloatingProfit")
                .HasPrecision(18, 8)
                .IsRequired();

            stats.Property(x => x.RealizedProfit)
                .HasColumnName("Statistics_RealizedProfit")
                .HasPrecision(18, 8)
                .IsRequired();

            stats.Property(x => x.Drawdown)
                .HasColumnName("Statistics_Drawdown")
                .HasPrecision(18, 8);

            stats.Property(x => x.MaxDrawdown)
                .HasColumnName("Statistics_MaxDrawdown")
                .HasPrecision(18, 8);

            stats.Ignore(x => x.TotalProfit);
        });

        builder.HasIndex(x => x.AccountId)
            .IsUnique();
    }
}