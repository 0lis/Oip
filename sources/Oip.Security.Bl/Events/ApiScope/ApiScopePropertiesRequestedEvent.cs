﻿using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiScope;

public class ApiScopePropertiesRequestedEvent : AuditEvent
{
    public ApiScopePropertiesRequestedEvent(int apiScopeId, ApiScopePropertiesDto apiScopeProperties)
    {
        ApiScopeId = apiScopeId;
        ApiResourceProperties = apiScopeProperties;
    }

    public int ApiScopeId { get; set; }
    public ApiScopePropertiesDto ApiResourceProperties { get; }
}