using Base.Core.Domains.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Resources.Shared.Base;
using Trading.Infrastructure.Persistence.Command.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations.Common;

public abstract class ConfigurationBase<TEntity>(string? schema = null) : IEntityTypeConfiguration<TEntity>
    where TEntity : AggregateRoot<BaseEntityId>
{
    private readonly string _schema = schema ?? Schema.Default;

    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(typeof(TEntity).Name, _schema);

        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
}