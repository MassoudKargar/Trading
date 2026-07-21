using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Portfolio;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class PortfolioQueryConfiguration
    : QueryConfigurationBase<PortfolioQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<PortfolioQueryModel> builder)
    {
        builder.ToTable("Portfolios", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Balance)
            .HasPrecision(18, 8);

        builder.Property(x => x.Equity)
            .HasPrecision(18, 8);

        builder.Property(x => x.FloatingProfit)
            .HasPrecision(18, 8);

        builder.Property(x => x.RealizedProfit)
            .HasPrecision(18, 8);

        builder.Property(x => x.TotalProfit)
            .HasPrecision(18, 8);

        builder.Property(x => x.Drawdown)
            .HasPrecision(18, 8);

        builder.Property(x => x.MaxDrawdown)
            .HasPrecision(18, 8);

        builder.HasIndex(x => x.AccountId);

        builder.HasIndex(x => x.CreatedAt);
    }
}
