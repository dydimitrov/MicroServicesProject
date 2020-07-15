using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Models;
using RealEstate.Models.Enums;
using Refit;

namespace RealEstate.Services.Properties
{
    public interface IPropertiesService
    {
        [Post("/Properties/Create")]
        Task<int> Create(string title, CurrencyType currency, decimal price, string description, DateTime CreatedOn, string address, string ownerId,string pictureUrl);
        
        [Get("/Properties/Details")]
        Task<Property> Details(int id);

        [Get("/Properties/All")]
        Task<IEnumerable<Property>> All();

        [Get("/Properties/MyProperties")]
        Task<IEnumerable<Property>> GetPropertiesByUsername(string username);

        [Post("/Properties/Delete")]
        Task<bool> Delete(int id);
    }
}
