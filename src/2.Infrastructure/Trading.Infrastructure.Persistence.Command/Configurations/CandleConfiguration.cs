using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Market;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class CandleConfiguration
    : ConfigurationBase<Candle>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Candle> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.TimeFrame)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.OpenTime)
            .IsRequired();

        builder.Property(x => x.CloseTime);

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

        builder.Property(x => x.IsClosed)
            .IsRequired();

        builder.HasIndex(x => x.Symbol);

        builder.HasIndex(x => x.OpenTime);

        builder.HasIndex(x => new
            {
                x.Symbol,
                x.TimeFrame,
                x.OpenTime
            })
            .IsUnique();

        builder.HasIndex(x => new
        {
            x.Symbol,
            x.TimeFrame,
            x.IsClosed
        });
    }
}