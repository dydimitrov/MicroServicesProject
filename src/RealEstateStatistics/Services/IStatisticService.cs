using System.Threading.Tasks;
using RealEstateStatistics.Models;

namespace RealEstateStatistics.Services
{
    public interface IStatisticService
    {
        Task<Statistics> All();

        Task AddProperty();
        Task AddAppointment();
        Task AddNewsLetter();
    }
}
