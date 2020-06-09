using System.ComponentModel.DataAnnotations;

namespace RealEstateWeb.Models.DbModels
{
    public class Address
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string State { get; set; }
        
        [Required]
        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string Town { get; set; }
        
        [Required]
        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string Neighborhood { get; set; }
        
        [Required]
        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string Street { get; set; }
    }
}
