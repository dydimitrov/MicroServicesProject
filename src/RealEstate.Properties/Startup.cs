namespace RealEstate.Properties
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RealEstate.Properties.Services;
    using RealEstateCommon.Infrastructure;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                  .AddWebService<PropertiesDbContext>(this.Configuration)
                  .AddMessaging();
            services.AddTransient<IPropertyService, PropertyService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
              .UseWebService(env);

            app.UseHttpsRedirection();
            var scope = app.ApplicationServices.CreateScope();
            scope.ServiceProvider.GetService<PropertiesDbContext>().Database.Migrate();
        }
    }
}
