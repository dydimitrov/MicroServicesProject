using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateWeb.Models.DbModels
{
    public class ViewAppointment
    {
        public string Id { get; set; }

        public DateTime DateOfAppointment { get; set; }

        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey("BuyerId")]
        public Client Buyer { get; set; }
        public int BuyerId { get; set; }

        public ApplicationUser Agent { get; set; }
    }
}
