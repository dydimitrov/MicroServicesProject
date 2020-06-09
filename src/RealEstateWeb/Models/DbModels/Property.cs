using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RealEstateWeb.Models.Enums;

namespace RealEstateWeb.Models.DbModels
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.TitleMaxLength, ErrorMessage = ModelConstants.TitleErrorMessage)]
        public string Title { get; set; }

        public CurrencyType Currency { get; set; }

        [Required]
        [Range(ModelConstants.PriceMinValue, ModelConstants.PriceMaxValue)]
        public decimal Price { get; set; }
        
        public string Description { get; set; }
        
        public PropertyPurpose PropertyPurpose { get; set; }

        public PropertyType PropertyType { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        public int AddressId { get; set; }

        [ForeignKey("PropertyDetailsId")]
        public PropertyDetails PropertyDetails { get; set; }
        public int PropertyDetailsId { get; set; }

        [ForeignKey("PropertyStatusId")]
        public PropertyStatus PropertyStatus { get; set; }
        public int PropertyStatusId { get; set; }

        [ForeignKey("OwnerId")]
        public Client Owner { get; set; }
        public int OwnerId { get; set; }

        [ForeignKey("FacilitiesId")]
        public NearByFacilities Facilities { get; set; }
        public int FacilitiesId { get; set; }

        public ApplicationUser Agent { get; set; }

        public ICollection<ViewAppointment> Views { get; set; } = new List<ViewAppointment>();

        public ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    }
}
