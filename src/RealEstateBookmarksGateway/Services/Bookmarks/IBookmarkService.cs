using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Bookmarks.Gateway.Models.Bookmarks;
using Refit;

namespace RealEstate.Bookmarks.Gateway.Services.Bookmarks
{
    public interface IBookmarkService
    {
        [Get("/Bookmarks/MyBookmarks")]
        Task<IEnumerable<Bookmark>> MyBookmarks(string username);
    }
}
