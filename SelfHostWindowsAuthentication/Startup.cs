using System.Collections.Generic;
using System.Linq;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Resources;
using IdentityServer3.Core.Services.InMemory;
using Owin;
using SelfHostWindowsAuthentication.Configuration;

namespace SelfHostWindowsAuthentication
{
    internal class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var options = new IdentityServerOptions
            {
                SiteName = "IdentityServer3 - WsFed",
                SigningCertificate = Certificate.Get(),
                Factory = CreateInMemoryServiceFactory()
            };

            appBuilder.UseIdentityServer(options);
        }

        private static IdentityServerServiceFactory CreateInMemoryServiceFactory()
        {
            return new IdentityServerServiceFactory()
                            .UseInMemoryUsers(new List<InMemoryUser>())
                            .UseInMemoryClients(Enumerable.Empty<Client>())
                            .UseInMemoryScopes(Enumerable.Empty<Scope>());
        }
    }
}