using System;
using System.Collections.Generic;
using System.Text;
using RealEstateWeb.Models.ViewModels.Property;

namespace RealEstateWeb.Models.ViewModels.Home
{
    public class IndexProperties
    {
        public List<PropertyIndexViewModel> Slider { get; set; }
        public List<PropertyIndexViewModel> BotumList { get; set; }
    }
}
