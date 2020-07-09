using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RealEstateNewsLetter.Data
{
    public class NewsLetterDbContextFactory : IDesignTimeDbContextFactory<NewsLetterDbContext>
    {
        public NewsLetterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NewsLetterDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-NQKNR5O\\SQL2017;Database=RealEstate_NewsLetter;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new NewsLetterDbContext(optionsBuilder.Options);
        }
    }
}
