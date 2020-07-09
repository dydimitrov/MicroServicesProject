using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateCommon.Services.Identity;
using RealEstateIndetity.Models;
using RealEstateIndetity.Services;

namespace RealEstateIndetity.Controllers
{

    public class UserController : ControllerBase
    {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;

        public UserController(
            IIdentityService identity,
            ICurrentUserService currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Route("api/register")]
        public async Task<ActionResult<UserOutputModel>> Register(UserInputModel input)
        {
            var result = await this.identity.Register(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return await Login(input);
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<ActionResult<UserOutputModel>> Login(UserInputModel input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new UserOutputModel(result.Data.Token);
        }
    }
}