using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateWeb.Infrastructure;
using RealEstateWeb.Services.Contract;

namespace RealEstateWeb.Controllers
{
    [CustomAuthorize]
    public class BookmarkController : BaseController
    {
        private readonly IBookmarkService _service;

        public BookmarkController(IBookmarkService service)
        {
            _service = service;
        }

        public IActionResult CreateBookmark(int id)
        {
            var user = this.User.Identity.Name;

            var result = this._service.Create(id, user);
            if (!result)
            {
                return this.RedirectToAction("Error", "Home");
            }
            return this.RedirectToAction("All", "Property");
        }
        
        public IActionResult MyBookmarks()
        {
            var username = this.User.Identity.Name;
            var model = this._service.MyBookmarks(username);
            return this.View(model);
        }
        
        public IActionResult Remove(int id)
        {
            this._service.Remove(id);
            return this.RedirectToAction("MyBookmarks","Bookmark");
        }
    }
}