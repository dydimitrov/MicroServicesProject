using System;
using System.Collections.Generic;
using System.Text;
using RealEstateWeb.Models.DbModels;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class SinglePropertyDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<string> PictureUrls { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public string Purpose { get; set; }

        public string Status { get; set; }

        public string PropertyType { get; set; }

        public string Description { get; set; }

        public AddressCreateViewModel Address { get; set; }

        public PropertyDetailsViewModel Details { get; set; }

        public FacilitiesViewModel Facilities { get; set; }

        public AgentViewModel Agent { get; set; }
    }
}
