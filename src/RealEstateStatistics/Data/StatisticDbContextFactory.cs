using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RealEstateStatistics.Data;

namespace RealEstate.Bookmarks.Data
{
    public class StatisticDbContextFactory : IDesignTimeDbContextFactory<StatisticDbContext>
    {
        public StatisticDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StatisticDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-NQKNR5O\\SQL2017;Database=RealEstate_Statistics;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new StatisticDbContext(optionsBuilder.Options);
        }
    }
}
