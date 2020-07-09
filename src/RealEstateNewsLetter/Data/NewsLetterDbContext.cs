using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealEstateNewsLetter.Models;

namespace RealEstateNewsLetter.Data
{
    public class NewsLetterDbContext : DbContext
    {
        public NewsLetterDbContext(DbContextOptions<NewsLetterDbContext> options)
            : base(options)
        {
        }

        public DbSet<NewsLetterClient> Subscribers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
