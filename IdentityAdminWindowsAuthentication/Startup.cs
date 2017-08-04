using System.Collections.Generic;
using IdentityAdmin.Configuration;
using IdentityAdmin.Core;
using IdentityAdmin.Logging;
using IdentityAdminWindowsAuthentication.Config;
using IdentityServer.WindowsAuthentication.Configuration;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Owin;

namespace IdentityAdminWindowsAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogProvider.SetCurrentLogProvider(new TraceSourceLogProvider());

            app.Map("/windows", ConfigureWindowsTokenProvider);
            app.Map("", adminApp =>
            {
                adminApp.UseCookieAuthentication(new CookieAuthenticationOptions()
                {
                    AuthenticationType = "Cookies"
                });

                adminApp.UseWsFederationAuthentication(new WsFederationAuthenticationOptions
                {
                    AuthenticationType = "Cookies",
                    MetadataAddress = "http://localhost:44333/windows",
                    Wtrealm = "urn:idsrv3"
                });

                adminApp.UseIdentityAdmin(new IdentityAdminOptions
                {
                    Factory = CreateIdentityAdminServiceFactory(),
                    AdminSecurityConfiguration = new AdminHostSecurityConfiguration
                    {
                        HostAuthenticationType = "Cookies",
                        AdminRoleName = "Admin",
                        NameClaimType = "IsIdentityAdministrator",
                        RoleClaimType = "true",
                    }
                });
            });
        }

        private static void ConfigureWindowsTokenProvider(IAppBuilder app)
        {
            app.UseWindowsAuthentication();
            app.UseWindowsAuthenticationService(new WindowsAuthenticationOptions
            {
                IdpReplyUrl = "https://localhost:44333/",
                IdpRealm = "urn:idsrv3",
                SigningCertificate = Certificate.Get(),
                CustomClaimsProvider = new AdditionalCustomClaimsProvider()
            });
        }

        private static IdentityAdminServiceFactory CreateIdentityAdminServiceFactory()
        {
            var factory = new IdentityAdminServiceFactory
            {
                IdentityAdminService = new Registration<IIdentityAdminService, InMemoryIdentityManagerService>()
            };
            var rand = new System.Random();
            var clients = ClientSeeder.Get(rand.Next(1000, 3000));
            var scopes = ScopeSeeder.Get(rand.Next(15));
            factory.Register(new Registration<ICollection<InMemoryScope>>(scopes));
            factory.Register(new Registration<ICollection<InMemoryClient>>(clients));
            return factory;
        }
    }
}