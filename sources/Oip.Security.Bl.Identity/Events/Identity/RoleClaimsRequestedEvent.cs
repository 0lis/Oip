using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity;

public class RoleClaimsRequestedEvent<TRoleClaimsDto> : AuditEvent
{
    public RoleClaimsRequestedEvent(TRoleClaimsDto roleClaims)
    {
        RoleClaims = roleClaims;
    }

    public TRoleClaimsDto RoleClaims { get; set; }
}