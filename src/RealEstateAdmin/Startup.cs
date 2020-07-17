using System.Reflection;
using RealEstate.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstateCommon.Infrastructure;
using RealEstateCommon.Services.Identity;
using Refit;
using RealEstate.Services;
using RealEstate.Services.Identity;
using RealEstate.Services.NewsLetter;
using RealEstate.Services.Properties;
using RealEstate.Services.Bookmarks;
using RealEstate.Services.BookmarksGatewey;
using RealEstate.Services.Statistic;

namespace RealEstate
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
                .AddTokenAuthentication(this.Configuration)
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtCookieAuthenticationMiddleware>()
                .AddControllersWithViews(options => options
                    .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services
                .AddRefitClient<IIdentityService>()
                .WithConfiguration(serviceEndpoints.Identity);

            services
                .AddRefitClient<IInformationService>()
                .WithConfiguration(serviceEndpoints.News);

            services
                .AddRefitClient<IPropertiesService>()
                .WithConfiguration(serviceEndpoints.Property);

            services
                .AddRefitClient<IBookmarkService>()
                .WithConfiguration(serviceEndpoints.Bookmark);

            services
                .AddRefitClient<IBookmarkGatewayService>()
                .WithConfiguration(serviceEndpoints.BookmarkGateway);

            services
                .AddRefitClient<IStatisticService>()
                .WithConfiguration(serviceEndpoints.Statistic);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage();
            }
            else
            {
                app
                    .UseExceptionHandler("/Home/Error")
                    .UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseJwtCookieAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapDefaultControllerRoute());
        }
    }
}
