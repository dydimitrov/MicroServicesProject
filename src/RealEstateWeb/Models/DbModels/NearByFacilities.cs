using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RealEstateWeb.Models.Enums;

namespace RealEstateWeb.Models.DbModels
{
    public class NearByFacilities
    {
        public int Id { get; set; }

        [Range(ModelConstants.DistanceMinValue, double.MaxValue)]
        [Required(ErrorMessage = ModelConstants.RequiredField)]
        public double FoodStores { get; set; }
        [Required(ErrorMessage = ModelConstants.RequiredField)]
        public DistanceType FoodStoreDistance { get; set; }

        [Range(ModelConstants.DistanceMinValue, double.MaxValue)]
        [Required(ErrorMessage = ModelConstants.RequiredField)]
        public double Hospitals{ get; set; }
        [Required(ErrorMessage = ModelConstants.RequiredField)]
        public DistanceType HospitalDistance { get; set; }

        [Range(ModelConstants.DistanceMinValue, double.MaxValue)]
        [Required(ErrorMessage = ModelConstants.RequiredField)]
        public double School { get; set; }
        [Required(ErrorMessage = ModelConstants.RequiredField)]
        public DistanceType SchoolDistance { get; set; }
    }
}
