using RealEstateWeb.Models;
using RealEstateWeb.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RealEstateWeb.Models.ViewModels.Contact;
using RealEstateWeb.Models.ViewModels.Bookmark;

namespace RealEstateWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<ViewAppointment> Appointments { get; set; }
        public DbSet<ContactRequestViewModel> ContactRequests { get; set; }
        public DbSet<NewsLetterClient> ClientsForNewsLetter { get; set; }
        public DbSet<BookmarkViewModel> Bookmarks { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}
