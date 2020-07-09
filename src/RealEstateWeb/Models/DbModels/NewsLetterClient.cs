using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstateWeb.Models.DbModels
{
    public class NewsLetterClient
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
