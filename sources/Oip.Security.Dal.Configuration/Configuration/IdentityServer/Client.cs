using System.Collections.Generic;
using Oip.Security.EntityFramework.Configuration.Configuration.Identity;

namespace Oip.Security.EntityFramework.Configuration.Configuration.IdentityServer;

public class Client : IdentityServer4.Models.Client
{
    public List<Claim> ClientClaims { get; set; } = new();
}