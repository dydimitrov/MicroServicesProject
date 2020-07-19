using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateCommon.Infrastructure;
using RealEstateCommon.Services;
using RealEstateStatistics.Data;
using RealEstateStatistics.Messages;
using RealEstateStatistics.Services;

namespace RealEstateStatistics
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
                .AddWebService<StatisticDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, StatisticsDataSeeder>()
                .AddTransient<IStatisticService, StatisticService>()
                .AddMessaging(typeof(PropertyCreateConsumer), typeof(AppointmentCreateConsumer), typeof(NewsLetterCreateConsumer))
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
            .UseWebService(env)
            .Initialize();
            var scope = app.ApplicationServices.CreateScope();
            scope.ServiceProvider.GetService<StatisticDbContext>().Database.Migrate();
        }
    }
}
