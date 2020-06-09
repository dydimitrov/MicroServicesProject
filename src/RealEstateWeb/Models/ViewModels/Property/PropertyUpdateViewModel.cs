using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RealEstateWeb.Models.DbModels;
using RealEstateWeb.Models.Enums;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class PropertyUpdateViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.TitleMaxLength, ErrorMessage = ModelConstants.TitleErrorMessage)]
        public string Title { get; set; }

        public CurrencyType Currency { get; set; }

        [Required]
        [Range(ModelConstants.PriceMinValue, ModelConstants.PriceMaxValue)]
        public decimal Price { get; set; }

        [MaxLength(ModelConstants.MessageLength)]
        public string Description { get; set; }

        public PropertyType PropertyType { get; set; }

        public PropertyPurpose PropertyPurpose { get; set; }

        public AddressCreateViewModel Address { get; set; }

        public NearByFacilities Facilities { get; set; }

        public PropertyStatus PropertyStatus { get; set; }
        
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

        [Required]
        [MaxLength(ModelConstants.NamesLength, ErrorMessage = ModelConstants.NameErrorMessage)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ModelConstants.NamesLength, ErrorMessage = ModelConstants.NameErrorMessage)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
