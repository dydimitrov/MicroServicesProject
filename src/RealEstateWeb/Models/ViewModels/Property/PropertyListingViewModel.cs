using System;
using System.Collections.Generic;
using System.Text;
using RealEstateWeb.Models.Enums;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class PropertyListingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public AddressCreateViewModel Address { get; set; }
        public string PictureUrl { get; set; }
        public string PropertyPurpose { get; set; }
        public PropertyDetailsViewModel Details { get; set; }
        public DateTime CreatedOn { get; set; }
        public CurrencyType CurrencyType { get; set; }

        public string Description { get; set; }

        public int OlderSpan =>  (int)(DateTime.UtcNow - this.CreatedOn).TotalDays;
    }
}
