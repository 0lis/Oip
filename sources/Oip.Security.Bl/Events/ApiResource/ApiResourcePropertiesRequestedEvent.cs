﻿using Oip.Security.BusinessLogic.Dtos.Configuration;
using Skoruba.AuditLogging.Events;

namespace Oip.Security.BusinessLogic.Events.ApiResource;

public class ApiResourcePropertiesRequestedEvent : AuditEvent
{
    public ApiResourcePropertiesRequestedEvent(int apiResourceId, ApiResourcePropertiesDto apiResourceProperties)
    {
        ApiResourceId = apiResourceId;
        ApiResourceProperties = apiResourceProperties;
    }

    public int ApiResourceId { get; set; }
    public ApiResourcePropertiesDto ApiResourceProperties { get; }
}