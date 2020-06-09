using RealEstateWeb.Models;
using RealEstateWeb.Models.DbModels;

namespace RealEstateWeb.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ViewAppointment> Appointments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PropertyDetails> PropertyDetails { get; set; }
        public DbSet<PropertyClient> PropertiesClients { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<NearByFacilities> Facilitieses { get; set; }
        public DbSet<NewsLetterClient> ClientsForNewsLetter { get; set; }
        public DbSet<BookmarkedProperty> Bookmarks { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PropertyClient>().HasKey(pc=> new {pc.PropertyId, pc.ClientId});

            base.OnModelCreating(builder);
        }
    }
}
