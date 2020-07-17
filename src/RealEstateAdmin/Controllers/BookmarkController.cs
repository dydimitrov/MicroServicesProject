using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models.Bookmarks;
using RealEstate.Services.Bookmarks;
using RealEstate.Services.BookmarksGatewey;
using RealEstate.Services.Properties;

namespace RealEstate.Controllers
{
    [Authorize]
    public class BookmarkController : Controller
    {
        private readonly IBookmarkService _service;
        private readonly IBookmarkGatewayService _gatewayService;

        public BookmarkController(IBookmarkService service, IPropertiesService propertyService, IBookmarkGatewayService gatewayService)
        {
            _service = service;
            _gatewayService = gatewayService;
        }

        public async Task<IActionResult> CreateBookmark(int id)
        {
            var user = this.User.Identity.Name;

            await this._service.Create(user,id);
            return this.RedirectToAction("All", "Property");
        }
                
        public async Task<IActionResult> Remove(int id)
        {
            await this._service.Delete(id);
            return this.RedirectToAction("MyBookmarks","Bookmark");
        }

        public async Task<IActionResult> MyBookmarks()
        {
            var user = this.User.Identity.Name;
            var model = await _gatewayService.MyBookmarks(user);
            return View(model);
        }
    }
}