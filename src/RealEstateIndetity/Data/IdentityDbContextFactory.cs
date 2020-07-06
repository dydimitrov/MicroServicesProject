using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RealEstateIndetity.Data;

namespace RealEstateWeb.Data
{
    public class RealEstateIdentityDbContextFactory : IDesignTimeDbContextFactory<RealEstateIdentityDbContext>
    {
        public RealEstateIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RealEstateIdentityDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-NQKNR5O\\SQL2017;Database=RealEstate_Identity;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new RealEstateIdentityDbContext(optionsBuilder.Options);
        }
    }
}
