﻿using System.Collections.Generic;
using IdentityServer4.Models;
using Client = Oip.Security.EntityFramework.Configuration.Configuration.IdentityServer.Client;

namespace Oip.Security.EntityFramework.Configuration.Configuration
{
    public class IdentityServerData
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<IdentityResource> IdentityResources { get; set; } = new List<IdentityResource>();
        public List<ApiResource> ApiResources { get; set; } = new List<ApiResource>();
        public List<ApiScope> ApiScopes { get; set; } = new List<ApiScope>();
    }
}
