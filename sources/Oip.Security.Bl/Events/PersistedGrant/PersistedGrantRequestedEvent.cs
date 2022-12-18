using Oip.Security.BusinessLogic.Dtos.Grant;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.PersistedGrant;

public class PersistedGrantRequestedEvent : AuditEvent
{
    public PersistedGrantRequestedEvent(PersistedGrantDto persistedGrant)
    {
        PersistedGrant = persistedGrant;
    }

    public PersistedGrantDto PersistedGrant { get; set; }
}