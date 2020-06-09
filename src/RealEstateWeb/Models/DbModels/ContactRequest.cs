using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstateWeb.Models.DbModels
{
    public class ContactRequest
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.NamesLength, ErrorMessage = ModelConstants.NameErrorMessage)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(ModelConstants.PhoneLength, ErrorMessage = ModelConstants.PhoneErrorMessage)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(ModelConstants.AddressLength,ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string City { get; set; }

        [Required]
        [MaxLength(ModelConstants.SubjectLength, ErrorMessage = ModelConstants.SubjectErrorMessage)]
        public string Subject { get; set; }

        [MaxLength(ModelConstants.MessageLength)]
        public string Message { get; set; }
    }
}
