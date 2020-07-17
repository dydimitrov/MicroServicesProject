using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstateStatistics.Data;
using RealEstateStatistics.Models;

namespace RealEstateStatistics.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly StatisticDbContext _context;
        public StatisticService(StatisticDbContext context)
        {
            _context = context;
        }
        public async Task AddAppointment()
        {
            var model =await this.All();
            model.AppointmentCount++;
            await _context.SaveChangesAsync();
        }

        public async Task AddNewsLetter()
        {
            var model = await this.All();
            model.NewsLetterCount++;
            await _context.SaveChangesAsync();
        }

        public async Task AddProperty()
        {
            var model = await this.All();
            model.PropertyCount++;
            await _context.SaveChangesAsync();
        }

        public async Task<Statistics> All()
        {
            return await _context.Statistics.FirstAsync();            
        }
    }
}
