using Skoruba.AuditLogging.Events;
using Oip.Security.BusinessLogic.Dtos.Configuration;

namespace Oip.Security.BusinessLogic.Events.Client
{
    public class ClientClonedEvent : AuditEvent
    {
        public ClientCloneDto Client { get; set; }

        public ClientClonedEvent(ClientCloneDto client)
        {
            Client = client;
        }
    }
}