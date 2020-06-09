using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class MyPropertiesViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Currency { get; set; }
        public string Title { get; set; }
        public string AddressStreet { get; set; }
        public string AddressTown { get; set; }
    }
}
