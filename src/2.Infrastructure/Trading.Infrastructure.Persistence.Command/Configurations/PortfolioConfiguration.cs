using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Portfolio;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

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

        builder.OwnsOne(x => x.Statistics, statistics =>
        {
            statistics.Property(x => x.Balance)
                .HasPrecision(18, 8);

            statistics.Property(x => x.Equity)
                .HasPrecision(18, 8);

            statistics.Property(x => x.FloatingProfit)
                .HasPrecision(18, 8);

            statistics.Property(x => x.RealizedProfit)
                .HasPrecision(18, 8);

            statistics.Property(x => x.Drawdown)
                .HasPrecision(18, 8);

            statistics.Property(x => x.MaxDrawdown)
                .HasPrecision(18, 8);

            statistics.Ignore(x => x.TotalProfit);
        });

        builder.HasIndex(x => x.AccountId)
            .IsUnique();
    }
}