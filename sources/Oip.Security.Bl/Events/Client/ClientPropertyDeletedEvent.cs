using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.Client;

public class ClientPropertyDeletedEvent : AuditEvent
{
    public ClientPropertyDeletedEvent(ClientPropertiesDto clientProperty)
    {
        ClientProperty = clientProperty;
    }

    public ClientPropertiesDto ClientProperty { get; set; }
}