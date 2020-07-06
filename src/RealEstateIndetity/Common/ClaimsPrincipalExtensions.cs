using System.Security.Claims;

namespace RealEstateIndetity.Common
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
            => user.IsInRole("Administrator");
    }
}
