using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateIndetity.Models;

namespace RealEstateIndetity.Data
{
    public class RealEstateIdentityDbContext : IdentityDbContext<User>
    {
        public RealEstateIdentityDbContext(DbContextOptions<RealEstateIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
