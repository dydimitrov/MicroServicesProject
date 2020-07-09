using System;

namespace RealEstateNewsLetter.Models
{
    public class Appointment
    {
        public string Id { get; set; }

        public DateTime DateOfAppointment { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
    }
}
