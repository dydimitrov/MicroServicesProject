using System;

namespace RealEstateNewsLetter.Models
{
    public class NewsLetterClient
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
