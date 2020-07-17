using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateCommon.Services;
using RealEstateStatistics.Models;

namespace RealEstateStatistics.Data
{
    public class StatisticsDataSeeder : IDataSeeder
    {
        private readonly StatisticDbContext db;

        public StatisticsDataSeeder(StatisticDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.Statistics.Any())
            {
                return;
            }

            this.db.Statistics.Add(new Statistics
            {
                PropertyCount = 0,
                AppointmentCount = 0,
                NewsLetterCount = 0
            });

            this.db.SaveChanges();
        }
    }
}
