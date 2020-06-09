using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RealEstateWeb.Models.DbModels;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class ClientCreateViewModel
    {
        [Required(ErrorMessage = ModelConstants.RequiredField)]
        [MaxLength(ModelConstants.NamesLength, ErrorMessage = ModelConstants.NameErrorMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ModelConstants.RequiredField)]
        [MaxLength(ModelConstants.NamesLength, ErrorMessage = ModelConstants.NameErrorMessage)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
