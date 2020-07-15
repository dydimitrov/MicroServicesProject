using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models.NewsLetter
{
    public class NewsLetterClient
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
