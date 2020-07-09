using System.Threading.Tasks;
using RealEstateCommon.Models.Identity;
using Refit;

namespace RealEstateWeb.Services.EndpointServices
{
    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);

        [Post("/Identity/Register")]
        Task<UserOutputModel> Register([Body] string Email, string Password);
    }
}
