using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RealEstateWeb.Models.DbModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(ModelConstants.NamesLength, ErrorMessage = ModelConstants.NameErrorMessage)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ModelConstants.NamesLength, ErrorMessage = ModelConstants.NameErrorMessage)]
        public string LastName { get; set; }
        public ICollection<Property> Properties{ get; set; } = new List<Property>();
        public ICollection<BookmarkedProperty> Bookmarks{ get; set; } = new List<BookmarkedProperty>();
    }
}
