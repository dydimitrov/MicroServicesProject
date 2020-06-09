using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RealEstateWeb.Models.DbModels;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class FacilitiesViewModel
    {

        [Range(ModelConstants.DistanceMinValue, double.MaxValue)]
        public double FoodStores { get; set; }
        public string FoodStoreDistance { get; set; }


        [Range(ModelConstants.DistanceMinValue, double.MaxValue)]
        public double Hospitals { get; set; }
        public string HospitalDistance { get; set; }


        [Range(ModelConstants.DistanceMinValue, double.MaxValue)]
        public double School { get; set; }
        public string SchoolDistance { get; set; }
    }
}
