using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Bookmarks.Gateway.Models;
using RealEstate.Bookmarks.Gateway.Models.Enums;
using Refit;

namespace RealEstate.Bookmarks.Gateway.Services.Properties
{
    public interface IPropertiesService
    {
        [Get("/Properties/Details")]
        Task<Property> Details(int id);
    }
}
