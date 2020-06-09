using Microsoft.AspNetCore.Mvc;
using RealEstateWeb.Infrastructure;
using RealEstateWeb.Services.Contract;

namespace RealEstateWeb.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }
        public IActionResult All()
        {
            var model = this._service.AllProperties();
            return View(model);
        }

        public IActionResult AllContactRequests()
        {
            var model = this._service.AllContactRequest();

            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteContact(int id)
        {
            this._service.DeleteContactRequest(id);
            return this.RedirectToAction("AllContactRequests","Admin");
        }
    }
}