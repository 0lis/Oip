using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.Client;

public class ClientsRequestedEvent : AuditEvent
{
    public ClientsRequestedEvent(ClientsDto clientsDto)
    {
        ClientsDto = clientsDto;
    }

    public ClientsDto ClientsDto { get; set; }
}