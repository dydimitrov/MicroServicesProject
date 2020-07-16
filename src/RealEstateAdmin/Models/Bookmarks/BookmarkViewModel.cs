using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models.Bookmarks
{
    public class BookmarkViewModel
    {
        public int BookMarkId { get; set; }
        public int PropertyId { get; set; }
        public string PictureUrl { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
    }
}
