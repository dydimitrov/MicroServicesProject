using Microsoft.AspNetCore.Mvc;
using RealEstateWeb.Models.ViewModels.News;
using RealEstateWeb.Services.Contract;

namespace RealEstateWeb.Controllers
{
    public class NewsController : BaseController
    {
        private readonly IInformationService _service;

        public NewsController(IInformationService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddToNewsLetter(string email)
        {
            bool result = _service.CreateNewsLetterClient(email);

            if (result)
            {
                return this.RedirectToAction("Index", "Home");
            }       
            return this.RedirectToAction("Error", "Home");
        }
    }
}
