using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Ticks;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class TickConfiguration
    : ConfigurationBase<Tick>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Tick> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Broker)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.Bid)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.Ask)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.LastPrice)
            .HasPrecision(18, 8);

        builder.Property(x => x.Volume)
            .HasPrecision(18, 8);

        builder.Property(x => x.Time)
            .IsRequired();

        builder.Property(x => x.ServerTime)
            .IsRequired();

        builder.Property(x => x.ReceivedAt)
            .IsRequired();

        builder.HasIndex(x => x.Symbol);
        builder.HasIndex(x => x.Time);
        builder.HasIndex(x => new { x.Symbol, x.Time });
    }
}