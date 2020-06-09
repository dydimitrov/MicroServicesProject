using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstateWeb.Models.DbModels
{
    public class Picture
    {
        public int Id { get; set; }
        public string CloudUrl { get; set; }
        public string PublicId { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}
