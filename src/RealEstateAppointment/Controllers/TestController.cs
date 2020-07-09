using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateCommon.Controllers;

namespace RealEstateAppointment.Controllers
{

    public class TestController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route("/Test/Full")]
        public IActionResult Full()
        {
            return null;
        } 
    }
}