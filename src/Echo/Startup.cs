using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Echo.Application;
using Echo.Domain;
using Echo.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Echo
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
            services.AddControllers().AddNewtonsoftJson();

            services.AddDbContext<EchoDbContext>(opt =>
            {
                const string connStringKey = "DB";

                var connString = Configuration.GetValue<string>(connStringKey);

                if (string.IsNullOrWhiteSpace(connString))
                    throw new ArgumentNullException($"No connection string configuration for '{connStringKey}' could be found. Ensure it exists in appsettings.json");

                Console.WriteLine(connString);

                opt.UseNpgsql(connString);
            });

            services.AddScoped<CreateEchoMessageUseCase>();

            services.AddScoped<GetEchoHistoryUseCase>();

            services.AddScoped<IEchoMessageRepository, EchoMessageRepositoryEf>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using var scope = app.ApplicationServices.CreateScope();
            using var db = scope.ServiceProvider.GetRequiredService<EchoDbContext>();
            db.Database.Migrate();

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
