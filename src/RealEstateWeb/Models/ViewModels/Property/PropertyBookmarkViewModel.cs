using System.ComponentModel.DataAnnotations;
using RealEstateWeb.Models.DbModels;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class PropertyBookmarkViewModel
    {
        public int Id { get; set; }

        [Range(ModelConstants.PriceMinValue, ModelConstants.PriceMaxValue)]
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }
        public string Currency { get; set; }

        [MaxLength(ModelConstants.TitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string AddressStreet { get; set; }

        [MaxLength(ModelConstants.AddressLength, ErrorMessage = ModelConstants.AddressErrorMessage)]
        public string AddressTown { get; set; }

    }
}