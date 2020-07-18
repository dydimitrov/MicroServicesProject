using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Bookmarks.Gateway.Services;
using RealEstate.Bookmarks.Gateway.Services.Bookmarks;
using RealEstate.Bookmarks.Gateway.Services.Properties;
using RealEstateCommon.Infrastructure;
using RealEstateCommon.Services.Identity;
using Refit;

namespace RealEstate.Bookmarks.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddTokenAuthentication(this.Configuration)
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtHeaderAuthenticationMiddleware>()
                .AddControllers();

            services
                .AddRefitClient<IBookmarkService>()
                .WithConfiguration(serviceEndpoints.Bookmark);

            services
                .AddRefitClient<IPropertiesService>()
                .WithConfiguration(serviceEndpoints.Property);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
            .UseWebService(env);


            app.UseJwtHeaderAuthentication();

        }
    }
}
