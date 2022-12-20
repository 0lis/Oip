using Oip.Security.Bl.Identity.Dtos.Grant;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.Bl.Identity.Events.PersistedGrant;

public class PersistedGrantIdentityRequestedEvent : AuditEvent
{
    public PersistedGrantIdentityRequestedEvent(PersistedGrantDto persistedGrant)
    {
        PersistedGrant = persistedGrant;
    }

    public PersistedGrantDto PersistedGrant { get; set; }
}