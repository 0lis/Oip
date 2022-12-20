using Oip.Security.Bl.Identity.Helpers;

namespace Oip.Security.Bl.Identity.Resources;

public interface IPersistedGrantAspNetIdentityServiceResources
{
    ResourceMessage PersistedGrantDoesNotExist();

    ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
}