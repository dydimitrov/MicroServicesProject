using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RealEstateIndetity.Data;
using RealEstateIndetity.Models;

namespace RealEstatIdentity.Middlewares
{
    public class DataSeederMiddleware
    {
        private readonly RequestDelegate _next;

        public DataSeederMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            RealEstateIdentityDbContext db,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
            var userRoleExists = roleManager.RoleExistsAsync("User").Result;
            
            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            }
            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }

            await _next(context);
        }
    }
}
