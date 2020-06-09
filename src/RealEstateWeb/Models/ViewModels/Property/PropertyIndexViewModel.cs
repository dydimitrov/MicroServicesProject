using System;
using System.Collections.Generic;
using System.Text;
using RealEstateWeb.Models.Enums;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class PropertyIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public AddressCreateViewModel Address { get; set; }
        public string PictureUrl { get; set; }
        public string PropertyPurpose { get; set; }
        public string PictureUrlMenuBottom { get; set; }
        public CurrencyType Currency { get; set; }
    }
}
