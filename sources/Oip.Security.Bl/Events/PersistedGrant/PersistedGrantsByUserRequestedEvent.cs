using Oip.Security.BusinessLogic.Dtos.Grant;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.PersistedGrant;

public class PersistedGrantsByUserRequestedEvent : AuditEvent
{
    public PersistedGrantsByUserRequestedEvent(PersistedGrantsDto persistedGrants)
    {
        PersistedGrants = persistedGrants;
    }

    public PersistedGrantsDto PersistedGrants { get; set; }
}