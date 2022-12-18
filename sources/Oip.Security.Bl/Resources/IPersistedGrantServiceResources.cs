using Oip.Security.BusinessLogic.Helpers;

namespace Oip.Security.BusinessLogic.Resources;

public interface IPersistedGrantServiceResources
{
    ResourceMessage PersistedGrantDoesNotExist();

    ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
}