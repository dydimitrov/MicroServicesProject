﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;
using RealEstateWeb.Models.DbModels;
using RealEstateWeb.Models.Enums;

namespace RealEstateWeb.Models.ViewModels.Property
{
    public class PropertyCreateViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage =ModelConstants.RequiredField)]
        public string Title { get; set; }

        [Required]
        public CurrencyType Currency { get; set; }

        [Range(ModelConstants.PriceMinValue,ModelConstants.PriceMaxValue)]
        [Required]
        public decimal Price { get; set; }

        [MaxLength(ModelConstants.MessageLength)]
        public string Description { get; set; }

        [Required]
        public PropertyType PropertyType { get; set; }

        [Required]
        public PropertyPurpose PropertyPurpose { get; set; }

        [Required]
        public AddressCreateViewModel Address { get; set; }

        [Required]
        public PropertyDetailsViewModel PropertyDetails { get; set; }

        [Required]
        public NearByFacilities Facilities { get; set; }

        [Required]
        public PropertyStatus PropertyStatus { get; set; }

        public ClientCreateViewModel Owner { get; set; }

        public ApplicationUser Agent { get; set; }

        public IEnumerable<IFormFile> Files { get; set; }  = new List<IFormFile>();
    }
}
