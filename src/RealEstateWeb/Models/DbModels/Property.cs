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
        public string Title { get; set; }

        public CurrencyType Currency { get; set; }
        public decimal Price { get; set; }
        
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Address { get; set; }
        public string PropertyStatus { get; set; }
        public int OwnerId { get; set; }

    }
}
