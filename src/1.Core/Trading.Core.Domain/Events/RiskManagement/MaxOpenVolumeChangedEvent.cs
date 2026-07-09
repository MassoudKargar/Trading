namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record MaxOpenVolumeChangedEvent(
    BaseEntityId RiskProfileId,
    decimal MaxOpenVolume)
    : DomainEvent;