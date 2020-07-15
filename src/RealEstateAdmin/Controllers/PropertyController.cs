using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Services.Properties;

namespace RealEstate.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertiesService _service;
        public PropertyController(IPropertiesService service)
        {
            _service = service;
        }
        [Authorize]
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

            return null;
        }

        //public IActionResult All()
        //{
        //    var model = this._service.AllProperty();
        //    return View(model);
        //}

        //public IActionResult Details(int id)
        //{
        //   var model = this._service.Details(id);
        //    if (model == null)
        //    {
        //        return this.RedirectToAction("Error", "Home");
        //    }
        //    return View(model);
        //}

        //public IActionResult MyProperty()
        //{
        //    var user = this.User.Identity.Name;
        //    var model = this._service.MyProperties(user);
        //    return this.View(model);
        //}

        //[HttpPost]
        //public IActionResult Remove(int id)
        //{
        //    var resutl = this._service.Remove(id);
        //    if (resutl)
        //    {
        //        return this.RedirectToAction("MyProperty", "Property");
        //    }
        //    else
        //    {
        //        return  new BadRequestObjectResult("The property can not be found!");
        //    }
        //}

        //public IActionResult Edit(int id)
        //{
        //    var model = this._service.Edit(id);
        //    return this.View(model);
        //}

        //[HttpPost]
        //public IActionResult Edit(PropertyUpdateViewModel model)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //        this._service.Update(model);
        //    }

        //    return this.RedirectToAction("Details","Property", new {id = model.Id});
        //}
    }
}