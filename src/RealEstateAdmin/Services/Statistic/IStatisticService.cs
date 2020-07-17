using System.Threading.Tasks;
using RealEstate.Models;
using Refit;

namespace RealEstate.Services.Statistic
{
    public interface IStatisticService
    {
        [Get("/Statistics/All")]
        Task<Statistics> All();
    }
}
