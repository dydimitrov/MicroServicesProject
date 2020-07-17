using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstateCommon.Controllers;
using RealEstateStatistics.Models;
using RealEstateStatistics.Services;

namespace RealEstateStatistics.Controllers
{

    public class StatisticController : ApiController
    {
        private readonly IStatisticService _service;
        public StatisticController(IStatisticService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("/Statistics/All")]
        public async Task<Statistics> All()
        {
            return await _service.All();
        }        
            
    }
}