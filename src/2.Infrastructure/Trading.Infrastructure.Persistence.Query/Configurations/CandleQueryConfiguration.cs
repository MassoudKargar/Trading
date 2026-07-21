using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Market;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class CandleQueryConfiguration
    : QueryConfigurationBase<CandleQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<CandleQueryModel> builder)
    {
        builder.ToTable("Candles", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.TimeFrame)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Open)
            .HasPrecision(18, 8);

        builder.Property(x => x.High)
            .HasPrecision(18, 8);

        builder.Property(x => x.Low)
            .HasPrecision(18, 8);

        builder.Property(x => x.Close)
            .HasPrecision(18, 8);

        builder.Property(x => x.Volume)
            .HasPrecision(18, 8);

        builder.HasIndex(x => x.Symbol);

        builder.HasIndex(x => x.OpenTime);

        builder.HasIndex(x => new
            {
                x.Symbol,
                x.TimeFrame,
                x.OpenTime
            })
            .IsUnique();

        builder.HasIndex(x => x.IsClosed);
    }
}
