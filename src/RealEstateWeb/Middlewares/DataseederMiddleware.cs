using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstateWeb.Data;
using RealEstateWeb.Models.DbModels;

namespace RealEstateWeb.Middlewares
{
    public class DataSeederMiddleware
    {
        private readonly RequestDelegate _next;

        public DataSeederMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            ApplicationDbContext db,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
            var userRoleExists = roleManager.RoleExistsAsync("User").Result;

            db.Database.Migrate();

            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            }
            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
