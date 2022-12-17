using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity
{
    public class RoleClaimsRequestedEvent<TRoleClaimsDto> : AuditEvent
    {
        public TRoleClaimsDto RoleClaims { get; set; }

        public RoleClaimsRequestedEvent(TRoleClaimsDto roleClaims)
        {
            RoleClaims = roleClaims;
        }
    }
}