using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record MaxOpenVolumeChangedEvent(
    BaseEntityId RiskProfileId,
    decimal MaxOpenVolume)
    : DomainEvent;