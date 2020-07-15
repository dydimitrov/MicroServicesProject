namespace RealEstate.Identity.Services.Identity
{
    using System.Threading.Tasks;
    using Data.Models;
    using Models.Identity;
    using RealEstateCommon.Services;

    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);
    }
}
