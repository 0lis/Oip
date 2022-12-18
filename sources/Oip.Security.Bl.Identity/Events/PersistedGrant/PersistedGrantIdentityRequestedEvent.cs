using Oip.Security.BusinessLogic.Identity.Dtos.Grant;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.PersistedGrant;

public class PersistedGrantIdentityRequestedEvent : AuditEvent
{
    public PersistedGrantIdentityRequestedEvent(PersistedGrantDto persistedGrant)
    {
        PersistedGrant = persistedGrant;
    }

    public PersistedGrantDto PersistedGrant { get; set; }
}