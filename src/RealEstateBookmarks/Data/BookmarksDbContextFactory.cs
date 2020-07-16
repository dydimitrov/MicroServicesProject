using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RealEstate.Bookmarks.Data
{
    public class BookmarksDbContextFactory : IDesignTimeDbContextFactory<BookmarksDbContext>
    {
        public BookmarksDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookmarksDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-NQKNR5O\\SQL2017;Database=RealEstate_Bookmarks;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BookmarksDbContext(optionsBuilder.Options);
        }
    }
}
