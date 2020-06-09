using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RealEstateWeb.Infrastructure;
using RealEstateWeb.Models.ViewModels.Property;
using RealEstateWeb.Services.Contract;
using X.PagedList;

namespace RealEstateWeb.Controllers
{
    public class PropertyController : BaseController
    {

        private readonly IPropertyService _service;

        public PropertyController(IPropertyService service)
        {
            _service = service;
        }

        
        [CustomAuthorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorize]
        public IActionResult Create(PropertyCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var agent = this.User.Identity.Name;
            var result = _service.CreateProperty(model, agent);

            if (result)
            {
                return this.RedirectToAction("All");
            }
            else
            {
                return this.View(model);
            }
        }

        public IActionResult All()
        {
            var model = this._service.AllProperty();
            return View(model);
        }

        public IActionResult Details(int id)
        {
           var model = this._service.Details(id);
            if (model == null)
            {
                return this.RedirectToAction("Error", "Home");
            }
            return View(model);
        }
        
        [CustomAuthorize]
        public IActionResult MyProperty()
        {
            var user = this.User.Identity.Name;
            var model = this._service.MyProperties(user);
            return this.View(model);
        }

        [HttpPost]
        [CustomAuthorize]
        public IActionResult Remove(int id)
        {
            var resutl = this._service.Remove(id);
            if (resutl)
            {
                return this.RedirectToAction("MyProperty", "Property");
            }
            else
            {
                return  new BadRequestObjectResult("The property can not be found!");
            }
        }

        [CustomAuthorize]
        public IActionResult Edit(int id)
        {
            var model = this._service.Edit(id);
            return this.View(model);
        }

        [HttpPost]
        [CustomAuthorize]
        public IActionResult Edit(PropertyUpdateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this._service.Update(model);
            }

            return this.RedirectToAction("Details","Property", new {id = model.Id});
        }
    }
}