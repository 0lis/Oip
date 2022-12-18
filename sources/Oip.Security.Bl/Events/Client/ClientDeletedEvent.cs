using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.Client;

public class ClientDeletedEvent : AuditEvent
{
    public ClientDeletedEvent(ClientDto client)
    {
        Client = client;
    }

    public ClientDto Client { get; set; }
}