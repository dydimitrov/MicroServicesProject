
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealEstateStatistics.Models;

namespace RealEstateStatistics.Data
{
    public class StatisticDbContext : DbContext
    {
        public StatisticDbContext(DbContextOptions<StatisticDbContext> options)
            : base(options)
        {
        }

        public DbSet<Statistics> Statistics { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
