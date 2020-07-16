using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Services.Properties;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertiesService _service;
        public HomeController(IPropertiesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.NewestProperty();
            if (model.Any())
            {
                return View(model);
            }
            return RedirectToAction("IndexNoProperties", "Home");
        }

        public IActionResult IndexNoProperties()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
