using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateCommon.Controllers;

namespace RealEstateNewsLetter.Controllers
{

    public class TestController : ApiController
    {
        [HttpGet]
        [Route(nameof(Full))]
        public IActionResult Full()
        {
            return null;
        } 
    }
}