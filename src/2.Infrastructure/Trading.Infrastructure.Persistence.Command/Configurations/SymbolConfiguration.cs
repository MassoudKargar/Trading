using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Symbols;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class SymbolConfiguration
    : ConfigurationBase<Symbol>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Symbol> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.BaseCurrency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.QuoteCurrency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Digits)
            .IsRequired();

        builder.Property(x => x.TickSize)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.LotSize)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.Spread)
            .HasPrecision(18, 8);

        builder.Property(x => x.IsTradable)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.OwnsOne(x => x.TradingHours, tradingHours =>
        {
            tradingHours.OwnsMany(x => x.Sessions, sessions =>
            {
                sessions.WithOwner();

                sessions.Property<long>("Id");
                sessions.HasKey("Id");

                sessions.Property(x => x.Day)
                    .IsRequired();

                sessions.Property(x => x.OpenTime)
                    .IsRequired();

                sessions.Property(x => x.CloseTime)
                    .IsRequired();

                sessions.Property(x => x.IsTradingDay)
                    .IsRequired();

                sessions.ToTable("SymbolSessions");
            });
        });

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}