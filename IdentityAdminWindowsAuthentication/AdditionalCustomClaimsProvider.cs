using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer.WindowsAuthentication.Services;

namespace IdentityAdminWindowsAuthentication
{
    internal class AdditionalCustomClaimsProvider : ICustomClaimsProvider
    {
        private const string AdminWindowsGroupName = "IdentityAdministrators";

        public Task TransformAsync(CustomClaimsProviderContext context)
        {
            if (context.WindowsPrincipal.IsInRole(AdminWindowsGroupName))
                context.OutgoingSubject.AddClaim(new Claim("IsIdentityAdministrator","true"));
            return Task.FromResult(0);
        }

    }
}