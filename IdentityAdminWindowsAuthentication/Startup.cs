using System.Collections.Generic;
using IdentityAdmin.Configuration;
using IdentityAdmin.Core;
using IdentityAdmin.Logging;
using IdentityAdminWindowsAuthentication.Config;
using Owin;

namespace IdentityAdminWindowsAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogProvider.SetCurrentLogProvider(new TraceSourceLogProvider());

            app.Map("/admin", adminApp =>
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
                adminApp.UseIdentityAdmin(new IdentityAdminOptions
                {
                    Factory = factory
                });
            });
        }
    }
}