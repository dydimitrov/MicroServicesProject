﻿using System;
using RealEstate.Properties.Models.Enums;

namespace RealEstate.Properties.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public CurrencyType Currency { get; set; }
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }
        
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Address { get; set; }
        public string OwnerId { get; set; }

    }
}
