using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RealEstateAppointment.Data
{
    public class AppointmentDbContextFactory : IDesignTimeDbContextFactory<AppointmentDbContext>
    {
        public AppointmentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppointmentDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-NQKNR5O\\SQL2017;Database=RealEstate_NewsLetter;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AppointmentDbContext(optionsBuilder.Options);
        }
    }
}
