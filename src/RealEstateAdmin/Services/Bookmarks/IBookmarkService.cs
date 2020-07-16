using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Models.Bookmarks;
using Refit;

namespace RealEstate.Services.Bookmarks
{
    public interface IBookmarkService
    {
        [Post("/Bookmarks/Create")]
        Task<bool> Create(string username, int propertyId);

        [Get("/Bookmarks/Delete")]
        Task<Bookmark> Delete(int id);

        [Get("/Bookmarks/MyBookmarks")]
        Task<IEnumerable<Bookmark>> MyBookmarks(string username);
    }
}
