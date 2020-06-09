using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstateWeb.Models.DbModels
{
    public class BookmarkedProperty
    {
        public int Id { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
