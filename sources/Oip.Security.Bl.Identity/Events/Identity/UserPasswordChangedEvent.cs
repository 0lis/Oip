using Skoruba.AuditLogging.Events;

namespace Oip.Security.Bl.Identity.Events.Identity;

public class UserPasswordChangedEvent : AuditEvent
{
    public UserPasswordChangedEvent(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }
}