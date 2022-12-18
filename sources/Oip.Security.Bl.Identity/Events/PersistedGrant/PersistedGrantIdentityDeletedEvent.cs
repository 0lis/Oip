using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.PersistedGrant;

public class PersistedGrantIdentityDeletedEvent : AuditEvent
{
    public PersistedGrantIdentityDeletedEvent(string key)
    {
        Key = key;
    }

    public string Key { get; set; }
}