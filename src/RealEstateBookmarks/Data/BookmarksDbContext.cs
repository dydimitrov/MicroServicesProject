
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealEstateNewsLetter.Models;

namespace RealEstate.Bookmarks.Data
{
    public class BookmarksDbContext : DbContext
    {
        public BookmarksDbContext(DbContextOptions<BookmarksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bookmark> Bookmarks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
