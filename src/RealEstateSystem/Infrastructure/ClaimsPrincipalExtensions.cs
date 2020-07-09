using System.Security.Claims;

namespace RealEstateCommon.Infrastructure
{
    using static Constants;

    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
            => user.IsInRole(AdministratorRoleName);
    }
}
