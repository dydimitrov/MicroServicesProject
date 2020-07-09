using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateCommon.Models;

namespace RealEstateAdmin.Models.Identity
{
    public class UserInputModel : IMapFrom<RegisterFormModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }


    }
}
