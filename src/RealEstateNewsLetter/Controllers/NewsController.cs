using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateCommon.Controllers;
using RealEstateNewsLetter.Data;
using RealEstateNewsLetter.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RealEstateNewsLetter.Controllers
{

    public class NewsController : ApiController
    {
        private readonly NewsLetterDbContext _context;
        public NewsController(NewsLetterDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("/News/Create")]
        public async Task Create(string email)
        {
            _context.Subscribers.Add(new NewsLetterClient() { Email = email });
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        [Route("/News/All")]
        public async Task<IEnumerable<NewsLetterClient>> All()
        {
            return await _context.Subscribers.ToListAsync();
        }

        [HttpGet]
        [Route("/News/Delete")]
        public async Task<bool> Delete(int id)
        {
            var model = await _context.Subscribers.Where(x => x.Id == id).FirstAsync();
            if (model != null)
            {
                _context.Subscribers.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}