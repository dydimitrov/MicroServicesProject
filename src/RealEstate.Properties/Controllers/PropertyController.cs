using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Properties.Data;
using RealEstate.Properties.Models;
using RealEstate.Properties.Models.Enums;
using RealEstate.Properties.Services;

namespace RealEstate.Properties.Controllers
{    
    public class PropertyController : Controller
    {
        private readonly IPropertyService _service;
        public PropertyController(IPropertyService service)
        {
            _service = service;
        }
        [Route("/Properties/Create")]
        [HttpPost]
        [Authorize]
        public async Task<int> Create(string title, CurrencyType currency, decimal price, string description, DateTime createdOn, string address, string ownerId,string pictureUrl)
        {
            var property = new Property()
            {
                Title = title,
                Currency = currency,
                Price=price,
                Description = description,
                CreatedOn = createdOn,
                Address = address,
                OwnerId = ownerId,
                PictureUrl = pictureUrl
            };
            await _service.Save(property);
            return property.Id;
        }

        [Route("/Properties/Details")]
        [HttpGet]
        public async Task<Property> Details(int id)
            => await this._service.FindById(id);

        [Route("/Properties/All")]
        [HttpGet]
        public async Task<IEnumerable<Property>> All()
            => await this._service.GetAll();

        [Route("/Properties/MyProperties")]
        [HttpGet]
        public async Task<IEnumerable<Property>> MyProperties(string username)
            => await this._service.GetAll();

        [Route("/Properties/Delete")]
        [HttpPost]
        public async Task<bool> Delete(int id)
            => await this._service.Delete(id);
    }
}