using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.PersistedGrant;

public class PersistedGrantsIdentityDeletedEvent : AuditEvent
{
    public PersistedGrantsIdentityDeletedEvent(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; set; }
}