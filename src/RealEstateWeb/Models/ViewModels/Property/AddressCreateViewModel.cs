using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RealEstateWeb.Models.DbModels;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class AddressCreateViewModel
    {
        [Required(ErrorMessage = ModelConstants.RequiredField)]
        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string State { get; set; }

        [Required(ErrorMessage = ModelConstants.RequiredField)]
        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string Town { get; set; }

        [Required(ErrorMessage = ModelConstants.RequiredField)]
        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = ModelConstants.RequiredField)]
        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string Street { get; set; }
    }
}
