using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateCommon.Infrastructure;
using RealEstateIndetity.Data;
using RealEstateIndetity.Services;
using RealEstateIndetity.Infrastructure;

namespace RealEstateIndetity
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
            services
                   .AddWebService<RealEstateIdentityDbContext>(this.Configuration)
                   .AddUserStorage()
                   .AddTransient<IIdentityService, IdentityService>()
                   .AddTransient<ITokenGeneratorService, TokenGeneratorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseWebService(env);
            
        }
    }
}
