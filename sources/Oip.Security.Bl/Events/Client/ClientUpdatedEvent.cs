using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.Client;

public class ClientUpdatedEvent : AuditEvent
{
    public ClientUpdatedEvent(ClientDto originalClient, ClientDto client)
    {
        OriginalClient = originalClient;
        Client = client;
    }

    public ClientDto OriginalClient { get; set; }
    public ClientDto Client { get; set; }
}