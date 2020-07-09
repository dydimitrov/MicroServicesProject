using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateWeb.Models.DbModels
{
    public class ViewAppointment
    {
        public string Id { get; set; }

        public DateTime DateOfAppointment { get; set; }
        public int PropertyId { get; set; }
    }
}
