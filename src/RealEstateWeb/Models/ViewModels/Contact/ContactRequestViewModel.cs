using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RealEstateWeb.Models.DbModels;

namespace RealEstateWeb.Models.ViewModels.Contact
{
    public class ContactRequestViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(ModelConstants.AddressLength,ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string City { get; set; }

        [MaxLength(ModelConstants.SubjectLength, ErrorMessage = ModelConstants.SubjectErrorMessage)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }
    }
}
