using System;
using System.Collections.Generic;
using System.Text;
using RealEstateWeb.Models.ViewModels.Contact;
using RealEstateWeb.Models.ViewModels.Property;

namespace RealEstateWeb.Services.Contract
{
    public interface IAdminService
    {
        List<MyPropertiesViewModel> AllProperties();

        List<ContactRequestViewModel> AllContactRequest();

        void DeleteContactRequest(int id);
    }
}
