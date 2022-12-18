using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.Client;

public class ClientPropertiesRequestedEvent : AuditEvent
{
    public ClientPropertiesRequestedEvent(ClientPropertiesDto clientProperties)
    {
        ClientProperties = clientProperties;
    }

    public ClientPropertiesDto ClientProperties { get; set; }
}