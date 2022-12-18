using Oip.Security.BusinessLogic.Helpers;

namespace Oip.Security.BusinessLogic.Resources;

public interface IClientServiceResources
{
    ResourceMessage ClientClaimDoesNotExist();

    ResourceMessage ClientDoesNotExist();

    ResourceMessage ClientExistsKey();

    ResourceMessage ClientExistsValue();

    ResourceMessage ClientPropertyDoesNotExist();

    ResourceMessage ClientSecretDoesNotExist();
}