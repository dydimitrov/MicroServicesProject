using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Services.Properties;
using RealEstateCommon.Models;

namespace RealEstate.Controllers
{
    public class PropertyController : AdministrationController
    {
        private readonly IPropertiesService _service;
        public PropertyController(IPropertiesService service)
        {
            _service = service;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Property model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await _service.Create(model.Title,model.Currency, model.Price,model.Description,model.CreatedOn,model.Address, this.User.Identity.Name, model.PictureUrl);

            return RedirectToAction("Details", "Property", new { id = result });
        }

        public async Task<IActionResult> All()
        {
                var model = await this._service.All();
                return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await this._service.Details(id);
            if (model == null)
            {
                return this.RedirectToAction("Error", "Home");
            }
            return View(model);
        }

        public async Task<IActionResult> MyProperty()
        {
            var user = this.User.Identity.Name;
            var model = await this._service.GetPropertiesByUsername(user);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var resutl = await this._service.Delete(id);
            if (resutl)
            {
                return this.RedirectToAction("MyProperty", "Property");
            }
            else
            {
                return new BadRequestObjectResult("The property can not be found!");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this._service.Details(id);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Property model)
        {
            if (this.ModelState.IsValid)
            {
               await this._service.Edit(model.Id, model.Title, model.Currency, model.Price,model.Description,model.CreatedOn,model.Address,model.OwnerId,model.PictureUrl);
            }

            return this.RedirectToAction("Details", "Property", new { id = model.Id });
        }
    }
}