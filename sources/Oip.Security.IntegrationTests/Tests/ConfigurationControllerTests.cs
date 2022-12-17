﻿using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Oip.Security.IntegrationTests.Common;
using Oip.Security.IntegrationTests.Tests.Base;
using Oip.Security.UI.Configuration.Constants;
using Xunit;

namespace Oip.Security.IntegrationTests.Tests
{
	public class ConfigurationControllerTests : BaseClassFixture
    {
        public ConfigurationControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ReturnSuccessWithAdminRole()
        {
            SetupAdminClaimsViaHeaders();

            foreach (var route in RoutesConstants.GetConfigureRoutes())
            {
                // Act
                var response = await Client.GetAsync($"/Configuration/{route}");

                // Assert
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }


        [Fact]
        public async Task ReturnRedirectWithoutAdminRole()
        {
            //Remove
            Client.DefaultRequestHeaders.Clear();
            
            foreach (var route in RoutesConstants.GetConfigureRoutes())
            {
                // Act
                var response = await Client.GetAsync($"/Configuration/{route}");

                // Assert           
                response.StatusCode.Should().Be(HttpStatusCode.Redirect);

                //The redirect to login
                response.Headers.Location.ToString().Should().Contain(AuthenticationConsts.AccountLoginPage);
            }
        }
    }
}