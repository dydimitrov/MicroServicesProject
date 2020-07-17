using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Services.Statistic;

namespace RealEstate.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;
        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _statisticService.All();
            return View(model);
        }
    }
}