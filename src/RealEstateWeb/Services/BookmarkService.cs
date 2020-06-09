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
            var user = this._context.Users.FirstOrDefault(u => u.UserName == username);
            var property = this._context.Properties.FirstOrDefault(p => p.Id == id);
            if (user !=null && property !=null)
            {
                var bookmark = new BookmarkedProperty
                {
                    Property = property,
                    User = user
                };

                this._context.Bookmarks.Add(bookmark);
                this._context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<BookmarkViewModel> MyBookmarks(string username)
        {
            return this._context.Bookmarks
                .Where(b => b.User.UserName == username)
                .Select(b => new BookmarkViewModel()
                {
                    Id = b.Id,
                    Property = new PropertyBookmarkViewModel()
                    {
                        Id = b.Property.Id,
                        Price = b.Property.Price,
                        Currency = b.Property.Currency.ToString(),
                        Title = b.Property.Title,
                        PictureUrl = b.Property.Pictures.FirstOrDefault().CloudUrl,
                        AddressStreet = b.Property.Address.Street,
                        AddressTown = b.Property.Address.Town
                    }
                }).ToList();
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
