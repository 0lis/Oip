using Skoruba.AuditLogging.Events;
using Oip.Security.BusinessLogic.Dtos.Configuration;

namespace Oip.Security.BusinessLogic.Events.Client
{
    public class ClientPropertyDeletedEvent : AuditEvent
    {
        public ClientPropertiesDto ClientProperty { get; set; }

        public ClientPropertyDeletedEvent(ClientPropertiesDto clientProperty)
        {
            ClientProperty = clientProperty;
        }
    }
}