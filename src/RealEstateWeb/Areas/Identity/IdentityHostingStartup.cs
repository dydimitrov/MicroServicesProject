using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(RealEstateWeb.Areas.Identity.IdentityHostingStartup))]
namespace RealEstateWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}