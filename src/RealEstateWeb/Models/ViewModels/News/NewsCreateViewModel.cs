using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstateWeb.Models.ViewModels.News
{
    public class NewsCreateViewModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
