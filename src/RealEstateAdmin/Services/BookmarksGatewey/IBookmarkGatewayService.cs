using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Models.Bookmarks;
using Refit;

namespace RealEstate.Services.BookmarksGatewey
{
    public interface IBookmarkGatewayService
    {
        [Get("/BookmarksGateway/MyBookmarks")]
        Task<IEnumerable<BookmarkViewModel>> MyBookmarks(string username);
    }
}
