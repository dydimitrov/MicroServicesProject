namespace RealEstate.Identity.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.Identity;
    using RealEstateCommon.Controllers;
    using RealEstateCommon.Services.Identity;
    using Services.Identity;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;

        public IdentityController(
            IIdentityService identity,
            ICurrentUserService currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Route("/Identity/Register")]
        public async Task<ActionResult<UserOutputModel>> Register(UserInputModel input)
        {
            var result = await this.identity.Register(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route("/Identity/Login")]
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