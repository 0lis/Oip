using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class UserDeletedEvent<TUserDto> : AuditEvent
{
    public UserDeletedEvent(TUserDto user)
    {
        User = user;
    }

    public TUserDto User { get; set; }
}