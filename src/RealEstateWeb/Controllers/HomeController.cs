using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWeb.Infrastructure;
using RealEstateWeb.Models;
using RealEstateWeb.Models.ViewModels.Contact;
using RealEstateWeb.Models.ViewModels.Home;
using RealEstateWeb.Services.Contract;

namespace RealEstateWeb.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IInformationService _service;
        private readonly IPropertyService _propertiyService;

        public HomeController(IInformationService service, IPropertyService propertiyService)
        {
            _service = service;
            _propertiyService = propertiyService;
        }

        public IActionResult Index()
        {
            var modelSlider = this._propertiyService.IndexProperties();
            var modelBotumn = this._propertiyService.RandomProperties();
            var model = new IndexProperties()
            {
                Slider = modelSlider,
                BotumList = modelBotumn
            };

            if (modelSlider == null || modelSlider.Count ==0 || modelBotumn == null || modelBotumn.Count == 0)
            {
                return this.View("IndexNoProperties");
            }
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactRequestViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this._service.CreateContactRequest( model.Name,  model.Email, model.PhoneNumber, model.City, model.Subject, model.Message);
            }
            else
            {
                return this.Contact();
            }
            return RedirectToAction("Index");            
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
