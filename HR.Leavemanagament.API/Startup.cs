using HR.Leavemanagament.Application;
using HR.Leavemanagament.Infrastructure;
using HR.Leavemanagament.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HR.Leavemanagament.API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigureApplicationServices();
            services.ConfigurationInfrastructureRegistration(_config);
            services.ConfigurePerisistenceService(_config);


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HR.Leavemanagament.API", Version = "v1" });
            });

            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                             builder => builder.AllowAnyOrigin()
                                               .AllowAnyMethod()
                                               .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR.Leavemanagament.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
