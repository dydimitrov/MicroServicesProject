using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstateWeb.Models.DbModels
{
    public class PropertyDetails
    {
        public int Id { get; set; }
        
        public int? NumberOfBedrooms { get; set; }

        public int? NumberOfBathrooms { get; set; }

        public int? NumberOfBeds { get; set; }

        [Required]
        [Range(ModelConstants.AreaMinValue, ModelConstants.AreaMaxValue)]
        public double HomeArea { get; set; }

        [Required]
        [Range(ModelConstants.AreaMinValue, ModelConstants.AreaMaxValue)]
        public double TotalArea { get; set; }

        public int? YearOfBuild { get; set; }

    }

    
}
