using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateCommon.Controllers;
using RealEstateNewsLetter.Data;
using RealEstateNewsLetter.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using RealEstateCommon.Messages;

namespace RealEstateNewsLetter.Controllers
{

    public class NewsController : ApiController
    {
        private readonly NewsLetterDbContext _context;
        private readonly IBus _publisher;
        public NewsController(NewsLetterDbContext context, IBus _publisher)
        {
            _context = context;
            _publisher = _publisher;
        }
        [HttpPost]
        [Route("/News/Create")]
        public async Task Create(string email)
        {
            _context.Subscribers.Add(new NewsLetterClient() { Email = email });
            await _context.SaveChangesAsync();
            await _publisher.Publish(new NewsLetterCreatedMessage()
            {
                Email = email
            });
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