using System.ComponentModel.DataAnnotations;

namespace RealEstateWeb.Models.DbModels
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.NamesLength, ErrorMessage = ModelConstants.NameErrorMessage)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ModelConstants.NamesLength, ErrorMessage = ModelConstants.NameErrorMessage)]
        public string LastName { get; set; }
        
        [Phone(ErrorMessage = ModelConstants.PhoneErrorMessage)]
        public string PhoneNumber { get; set; }
    }
}
