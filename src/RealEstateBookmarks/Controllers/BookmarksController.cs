using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateCommon.Controllers;
using RealEstateNewsLetter.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RealEstate.Bookmarks.Data;

namespace RealEstate.Bookmarks.Controllers
{

    public class BookmarksController : ApiController
    {
        private readonly BookmarksDbContext _context;
        public BookmarksController(BookmarksDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("/Bookmarks/Create")]
        public async Task<bool> Create(string username, int propertyId)
        {
            _context.Bookmarks.Add(new Bookmark() { Username = username, PropertyId = propertyId });
            await _context.SaveChangesAsync();
            return true;
        }
        
        [HttpGet]
        [Route("/Bookmarks/Delete")]
        public async Task<bool> Delete(int id)
        {
            var model = await _context.Bookmarks.Where(x => x.Id == id).FirstAsync();
            if (model != null)
            {
                _context.Bookmarks.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpGet]
        [Route("/Bookmarks/MyBookmarks")]
        public async Task<IEnumerable<Bookmark>> MyBookmarks(string username)
            => await _context.Bookmarks.Where(x => x.Username == username).ToListAsync();
    }
}