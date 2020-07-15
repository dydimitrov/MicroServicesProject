using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Properties.Data;
using RealEstate.Properties.Models;
using RealEstate.Properties.Models.Enums;

namespace RealEstate.Properties.Controllers
{    
    public class PropertyController : Controller
    {
        private readonly PropertiesDbContext _context;
        public PropertyController(PropertiesDbContext context)
        {
            _context = context;
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
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
            return property.Id;
        }

    }
}