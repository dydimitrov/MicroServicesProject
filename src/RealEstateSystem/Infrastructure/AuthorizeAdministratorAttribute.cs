using Microsoft.AspNetCore.Authorization;

namespace RealEstateCommon.Infrastructure
{
    using static Constants;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRoleName;
    }
}
