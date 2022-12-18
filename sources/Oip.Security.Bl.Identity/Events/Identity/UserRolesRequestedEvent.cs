using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class UserRolesRequestedEvent<TUserRolesDto> : AuditEvent
{
    public UserRolesRequestedEvent(TUserRolesDto roles)
    {
        Roles = roles;
    }

    public TUserRolesDto Roles { get; set; }
}