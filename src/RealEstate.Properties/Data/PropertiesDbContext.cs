namespace RealEstate.Properties.Data
{
    using System.Reflection;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RealEstate.Properties.Models;

    public class PropertiesDbContext : DbContext
    {
        public PropertiesDbContext(DbContextOptions<PropertiesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
