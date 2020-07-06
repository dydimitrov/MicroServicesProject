using System.Threading.Tasks;
using RealEstateIndetity.Models;

namespace RealEstateIndetity.Services
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);
    }
}
