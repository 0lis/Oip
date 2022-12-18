using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class UserSavedEvent<TUserDto> : AuditEvent
{
    public UserSavedEvent(TUserDto user)
    {
        User = user;
    }

    public TUserDto User { get; set; }
}