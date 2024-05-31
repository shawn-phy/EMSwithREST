using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EMSwithREST.DataProvider;


using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace EMSwithREST
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // this method gets called by the runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
          
            //Because we need singleton to implement dependecy injection 
            //services.AddTransient<IUserDataProvider, UserDataProvider>();
            services.AddControllers();
            services.AddSingleton<IEventDataProvider, EventDataProvider>();

            //experimenting with swagger ;p
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventManagement API", Version = "v1" });
            });

        }
        // this method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            //more swagger stuff
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventManagement API v1"));
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
