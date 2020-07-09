using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using RealEstateWeb.Data;
using RealEstateWeb.Models.DbModels;
using RealEstateWeb.Models.ViewModels.Bookmark;
using RealEstateWeb.Models.ViewModels.Property;
using RealEstateWeb.Services.Contract;

namespace RealEstateWeb.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly ApplicationDbContext _context;

        public BookmarkService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(int id, string username)
        {
            //var user = this._context.Users.FirstOrDefault(u => u.UserName == username);
            var property = this._context.Properties.FirstOrDefault(p => p.Id == id);

            try
            {
                var bookmark = new BookmarkViewModel
                {
                    Property = 1,
                    User = 1
                };

                this._context.Bookmarks.Add(bookmark);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Remove(int id)
        {
            var bookmark = this._context.Bookmarks.FirstOrDefault(b => b.Id == id);
            if (bookmark !=null)
            {
                this._context.Bookmarks.Remove(bookmark);
                this._context.SaveChanges();
            }
            
        }
    }
}
