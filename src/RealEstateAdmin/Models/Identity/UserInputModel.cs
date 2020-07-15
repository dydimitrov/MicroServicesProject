using RealEstateCommon.Models;

namespace RealEstate.Models.Identity
{
    public class UserInputModel : IMapFrom<RegisterFormModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }


    }
}
