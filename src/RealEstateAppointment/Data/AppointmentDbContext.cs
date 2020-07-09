using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealEstateNewsLetter.Models;

namespace RealEstateAppointment.Data
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
