using System;

namespace RealEstate.Models.Bookmarks
{
    public class Bookmark
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Username { get; set; }
    }
}
