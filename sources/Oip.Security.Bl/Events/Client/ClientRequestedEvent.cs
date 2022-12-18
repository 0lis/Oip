using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.Client;

public class ClientRequestedEvent : AuditEvent
{
    public ClientRequestedEvent(ClientDto clientDto)
    {
        ClientDto = clientDto;
    }

    public ClientDto ClientDto { get; set; }
}