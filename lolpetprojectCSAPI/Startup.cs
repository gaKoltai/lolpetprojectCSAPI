using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lolpetprojectCSAPI.Interfaces;
using lolpetprojectCSAPI.Services;
using lolpetprojectCSAPI.Services.RiotApiServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace lolpetprojectCSAPI
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
            services.AddScoped(typeof(ISummonerRepository), typeof(SummonerRepository));
            services.AddScoped(typeof(IMatchHistoryRepository), typeof(MatchHistoryRepository));
            services.AddScoped(typeof(IMatchSpecificRepository), typeof(MatchSpecificRepository));
            services.AddScoped(typeof(IQueueStatRepository), typeof(QueueStatRepository));
            services.AddScoped(typeof(IApiKeyProvider), typeof(ApiKeyProvider));
            services.AddScoped(typeof(IApiRouter), typeof(ApiRouter));
            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}