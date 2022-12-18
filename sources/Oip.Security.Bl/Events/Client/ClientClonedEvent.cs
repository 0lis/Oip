using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.Client;

public class ClientClonedEvent : AuditEvent
{
    public ClientClonedEvent(ClientCloneDto client)
    {
        Client = client;
    }

    public ClientCloneDto Client { get; set; }
}