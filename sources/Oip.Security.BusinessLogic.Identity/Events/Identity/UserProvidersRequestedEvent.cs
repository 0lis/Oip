using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Identity.Events.Identity
{
    public class UserProvidersRequestedEvent<TUserProvidersDto> : AuditEvent
    {
        public TUserProvidersDto Providers { get; set; }

        public UserProvidersRequestedEvent(TUserProvidersDto providers)
        {
            Providers = providers;
        }
    }
}