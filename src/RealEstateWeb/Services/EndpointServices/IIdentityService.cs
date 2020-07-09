using System.Threading.Tasks;
using RealEstateIndetity.Models;
using Refit;

namespace RealEstateWeb.Services.EndpointServices
{
    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
