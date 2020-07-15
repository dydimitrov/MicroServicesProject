using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Services.NewsLetter;

namespace RealEstateWeb.Controllers
{
    public class NewsController : Controller
    {
        private readonly IInformationService _service;

        public NewsController(IInformationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddToNewsLetter(string email)
        {
            await _service.Create(email);
                return this.RedirectToAction("Index", "Home");
        }
    }
}
