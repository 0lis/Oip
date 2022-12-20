﻿using Oip.Security.Bl.Helpers;
using Oip.Security.Bl.Resources;

namespace Oip.Security.Bl.Resources;

public class PersistedGrantServiceResources : IPersistedGrantServiceResources
{
    public virtual ResourceMessage PersistedGrantDoesNotExist()
    {
        return new ResourceMessage
        {
            Code = nameof(PersistedGrantDoesNotExist),
            Description = PersistedGrantServiceResource.PersistedGrantDoesNotExist
        };
    }

    public virtual ResourceMessage PersistedGrantWithSubjectIdDoesNotExist()
    {
        return new ResourceMessage
        {
            Code = nameof(PersistedGrantWithSubjectIdDoesNotExist),
            Description = PersistedGrantServiceResource.PersistedGrantWithSubjectIdDoesNotExist
        };
    }
}