using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateWeb.Services;
using RealEstateWeb.Services.Contract;
using RealEstateWeb.Data;
using RealEstateWeb.Services.EndpointServices;
using AutoMapper;
using System;
using System.Reflection;
using Refit;
using System.Net.Http.Headers;
using RealEstateCommon.Models;
using RealEstateCommon.Services.Identity;
using RealEstateWeb.Common;

namespace RealEstateWeb
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
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                options.EnableEndpointRouting = false;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            

            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services.AddControllersWithViews(options => options
                    .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services
                .AddRefitClient<IIdentityService>()
                    .ConfigureHttpClient((serviceProvider, client) =>
                    {
                    client.BaseAddress = new Uri(this.Configuration.GetSection(nameof(ServiceEndpoints)).GetValue<string>("Identity"));

                    var requestServices = serviceProvider
                        .GetService<IHttpContextAccessor>()
                        ?.HttpContext
                        .RequestServices;

                    var currentToken = requestServices
                        ?.GetService<ICurrentTokenService>()
                        ?.Get();

                    if (currentToken == null)
                    {
                        return;
                    }

                    var authorizationHeader = new AuthenticationHeaderValue("Bearer", currentToken);
                    client.DefaultRequestHeaders.Authorization = authorizationHeader;
                    });

            services
                .AddAutoMapper(
                    (_, config) => config
                        .AddProfile(new MappingProfile(Assembly.GetCallingAssembly())),
                    Array.Empty<Assembly>());

            services.AddTokenAuthentication(this.Configuration);
            //Adding Services
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IInformationService, InformationService>();
            services.AddScoped<IBookmarkService, BookmarkService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAdminService, AdminService>();

            services.AddMvc(options =>
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            ).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
