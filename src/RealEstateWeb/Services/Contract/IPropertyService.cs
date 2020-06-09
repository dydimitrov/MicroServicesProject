using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using RealEstateWeb.Models.DbModels;
using RealEstateWeb.Models.ViewModels.Property;

namespace RealEstateWeb.Services.Contract
{
    public interface IPropertyService
    {
        bool CreateProperty(PropertyCreateViewModel model, string agentUsername);

        List<PropertyIndexViewModel> IndexProperties();

        List<PropertyIndexViewModel> RandomProperties();

        IEnumerable<PropertyListingViewModel> AllProperty();

        SinglePropertyDetailsViewModel Details(int id);

        List<MyPropertiesViewModel> MyProperties(string username);

        bool Remove(int id);

        PropertyUpdateViewModel Edit(int id);

        void Update(PropertyUpdateViewModel model);

    }
}
