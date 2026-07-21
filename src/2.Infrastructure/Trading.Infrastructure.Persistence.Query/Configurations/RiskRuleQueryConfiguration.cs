using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.RiskManagement;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class RiskRuleQueryConfiguration
    : QueryConfigurationBase<RiskRuleQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<RiskRuleQueryModel> builder)
    {
        builder.ToTable("RiskRules", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.HasIndex(x => x.RiskProfileId);
    }
}
