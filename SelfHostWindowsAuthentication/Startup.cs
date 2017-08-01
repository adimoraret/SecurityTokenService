using System.Collections.Generic;
using System.Linq;
using IdentityServer.WindowsAuthentication.Configuration;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using Microsoft.Owin.Security.WsFederation;
using Owin;
using SelfHostWindowsAuthentication.Configuration;

namespace SelfHostWindowsAuthentication
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/windows", ConfigureWindowsTokenProvider);

            var options = new IdentityServerOptions
            {
                SiteName = Application.Title,
                SigningCertificate = Certificate.Get(),
                Factory = CreateInMemoryServiceFactory(),
                AuthenticationOptions = new AuthenticationOptions
                {
                    EnableLocalLogin = true,
                    IdentityProviders = ConfigureIdentityProviders
                }
            };
            app.UseIdentityServer(options);
        }

        private static void ConfigureWindowsTokenProvider(IAppBuilder app)
        {
            app.UseWindowsAuthentication();
            app.UseWindowsAuthenticationService(new WindowsAuthenticationOptions
            {
                IdpReplyUrl = Application.StsWindowsAuth,
                IdpRealm = "urn:idsrv3",
                SigningCertificate = Certificate.Get()
            });
        }

        private static void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            var wsFederation = new WsFederationAuthenticationOptions
            {
                AuthenticationType = "windows",
                Caption = "Login with Windows",
                SignInAsAuthenticationType = signInAsType,
                MetadataAddress = Application.StsWindowsUrl,
                Wtrealm = "urn:idsrv3"
            };
            app.UseWsFederationAuthentication(wsFederation);
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