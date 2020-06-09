using RealEstateWeb.Models.ViewModels.Property;

namespace RealEstateWeb.Models.ViewModels.Bookmark
{
    public class BookmarkViewModel
    {
        public int Id { get; set; }

        public PropertyBookmarkViewModel Property { get; set; }
    }
}