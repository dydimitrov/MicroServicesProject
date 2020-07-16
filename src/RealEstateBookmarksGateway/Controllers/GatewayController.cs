using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateCommon.Controllers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RealEstate.Bookmarks.Gateway.Services.Properties;
using RealEstate.Bookmarks.Gateway.Services.Bookmarks;
using RealEstate.Bookmarks.Gateway.Models;

namespace RealEstate.Bookmarks.Gateway.Controllers
{

    public class GatewayController : ApiController
    {
        private readonly IPropertiesService _properties;
        private readonly IBookmarkService _bookmarks;
        public GatewayController(IPropertiesService properties, IBookmarkService bookmarks)
        {
            _bookmarks = bookmarks;
            _properties = properties;
        }

        [HttpGet]
        [Route("/BookmarksGateway/MyBookmarks")]
        public async Task<IEnumerable<BookmarkViewModel>> MyBookmarks(string username)
        {
            var bookmarks = await this._bookmarks.MyBookmarks(username);

            var model = new List<BookmarkViewModel>();
            foreach (var item in bookmarks)
            {
                var property = await _properties.Details(item.PropertyId);
                model.Add(new BookmarkViewModel()
                {
                    BookMarkId = item.Id,
                    PictureUrl = property.PictureUrl,
                    PropertyId = item.PropertyId,
                    Address = property.Address,
                    Price = property.Price,
                    Title = property.Title
                });
            }
            return model;
        }    
    }
}