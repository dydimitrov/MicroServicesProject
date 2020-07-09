using System.Security.Claims;

namespace RealEstateCommon
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
            => user.IsInRole("Administrator");
    }
}
