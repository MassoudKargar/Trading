using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Market;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class TickQueryConfiguration
    : QueryConfigurationBase<TickQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<TickQueryModel> builder)
    {
        builder.ToTable("Ticks", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Bid)
            .HasPrecision(18, 8);

        builder.Property(x => x.Ask)
            .HasPrecision(18, 8);

        builder.Property(x => x.Last)
            .HasPrecision(18, 8);

        builder.Property(x => x.Volume)
            .HasPrecision(18, 8);

        builder.HasIndex(x => x.Symbol);

        builder.HasIndex(x => x.Time);

        builder.HasIndex(x => new
        {
            x.Symbol,
            x.Time
        });
    }
}
