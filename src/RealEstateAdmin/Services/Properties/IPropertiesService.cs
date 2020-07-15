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
    }
}
